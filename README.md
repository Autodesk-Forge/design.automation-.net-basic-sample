# Design Automation API Basic Sample in C#
(Formely AutoCAD I/O)

[![.net](https://img.shields.io/badge/.net-4.5-green.svg)](http://www.microsoft.com/en-us/download/details.aspx?id=30653)
[![odata](https://img.shields.io/badge/odata-4.0-yellow.svg)](http://www.odata.org/documentation/)
[![Design Automation](https://img.shields.io/badge/Design%20Automation-v2-green.svg)](http://developer.autodesk.com/)
[![visual studio](https://img.shields.io/badge/visual%20studio-2015%2F2017-yellowgreen.svg)](https://www.visualstudio.com/)
[![License](http://img.shields.io/:license-mit-red.svg)](http://opensource.org/licenses/MIT)


## Description

This is the simplest C# client that uses the predefined PlotToPDF activity of AutoCAD Design Automation . It is the sample for the tutorial of design automation API.

## Thumbnail
![thumbnail](/thumbnail.png)  

## Setup

### Dependencies 
* Download [Visual Studio](https://visualstudio.microsoft.com/downloads/) 

### Prerequisites
1. **Forge Account**: Learn how to create a Forge Account, activate subscription and create an app at [this tutorial](http://learnforge.autodesk.io/#/account/). Make sure to select the service **Design Automation**.
2. Make a note with the credentials (client id and client secret) of the app. 

## Running locally   
1. Restore the packages of the project by [NuGet](https://www.nuget.org/). The simplest way is
  * VS2012: Projects tab >> Enable NuGet Package Restore. Then right click the project>>"Manage NuGet Packages for Solution" >> "Restore" (top right of dialog)
  * VS2013/VS2015/2017:  right click the project>>"Manage NuGet Packages for Solution" >> "Restore" (top right of dialog)
2. Apply credencials of Design Automation API from https://developer.autodesk.com/. Put your   Forge credentials in [program.cs](./Program.cs) 
3. Run project, you will see a status in the console:
4. if everything works well, the result file (pdf) and the report files will be downloaded at **MyDocuments**.
5. if there is any error with the process, check the report file what error is indicated.

## Further Reading 
* [Design Automation API help](https://forge.autodesk.com/en/docs/design-automation/v2/developers_guide/overview/)
 
* [ Intro to Design Automation API Video](https://www.youtube.com/watch?v=GWsJM344CJE&t=107s)


## License

These samples are licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

## Written by 

Jonathan Miao & Albert Szilvasy
