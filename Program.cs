using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using AIO.Operations;
using AIO.ACES.Models;

namespace workflow_simplest_autocad.io
{
    class Credentials
    {
        //get your ConsumerKey/ConsumerSecret at http://developer.autodesk.com
        public static string ConsumerKey = "<Your Key>";
        public static string ConsumerSecret = "<Your Secret>";
    }
    class Program
    {
        static string GetToken()
        {
            using (var client = new HttpClient())
            {
                var values = new List<KeyValuePair<string, string>>();
                values.Add(new KeyValuePair<string, string>("client_id", Credentials.ConsumerKey));
                values.Add(new KeyValuePair<string, string>("client_secret", Credentials.ConsumerSecret));
                values.Add(new KeyValuePair<string, string>("grant_type", "client_credentials"));
                var requestContent = new FormUrlEncodedContent(values);
                var response = client.PostAsync("https://developer.api.autodesk.com/authentication/v1/authenticate", requestContent).Result;
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var resValues = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                return resValues["token_type"] + " " + resValues["access_token"];
            }
        }

        static void DownloadToDocs(string url, string localFile)
        {
            var client = new HttpClient();
            var content = (StreamContent)client.GetAsync(url).Result.Content;
            var fname = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), localFile);
            Console.WriteLine("Downloading to {0}.", fname);
            using (var output = System.IO.File.Create(fname))
            {
                content.ReadAsStreamAsync().Result.CopyTo(output);
                output.Close();
            }
        }
        
        static void Main(string[] args)
        {
            //instruct client side library to insert token as Authorization value into each request
            var container = new Container(new Uri("https://developer.api.autodesk.com/autocad.io/us-east/v2/"));
            var token = GetToken();
            container.SendingRequest2 += (sender, e) => e.RequestMessage.SetHeader("Authorization", token);

            //create a workitem
            var wi = new WorkItem()
            {
                Id = "", //must be set to empty
                Arguments = new Arguments(),
                ActivityId = "PlotToPDF" //PlotToPDF is a predefined activity
            };

            wi.Arguments.InputArguments.Add(new Argument()
                {
                    Name = "HostDwg",// Must match the input parameter in activity
                    Resource = "http://download.autodesk.com/us/samplefiles/acad/blocks_and_tables_-_imperial.dwg",
                    StorageProvider = StorageProvider.Generic //Generic HTTP download (as opposed to A360)
                });
            wi.Arguments.OutputArguments.Add(new Argument()
            {
                Name = "Result", //must match the output parameter in activity
                StorageProvider = StorageProvider.Generic, //Generic HTTP upload (as opposed to A360)
                HttpVerb = HttpVerbType.POST, //use HTTP POST when delivering result
                Resource = null //use storage provided by Design Automation
            });

            container.AddToWorkItems(wi);
            Console.WriteLine("Submitting workitem...");
            container.SaveChanges();

            //polling loop
            do
            {
                Console.WriteLine("Sleeping for 2 sec...");
                System.Threading.Thread.Sleep(2000);
                container.LoadProperty(wi, "Status"); //http request is made here
                Console.WriteLine("WorkItem status: {0}", wi.Status);
            }
            while (wi.Status == ExecutionStatus.Pending || wi.Status == ExecutionStatus.InProgress);

            //re-query the service so that we can look at the details provided by the service
            container.MergeOption = Microsoft.OData.Client.MergeOption.OverwriteChanges;
            wi = container.WorkItems.ByKey(wi.Id).GetValue();
            
            //Resource property of the output argument "Result" will have the output url
            var url = wi.Arguments.OutputArguments.First(a => a.Name == "Result").Resource;
            DownloadToDocs(url, "DesignAutomation.pdf");
            
            //download the status report
            url = wi.StatusDetails.Report;
            DownloadToDocs(url, "DesignAutomation.txt");
        }
    }
}
