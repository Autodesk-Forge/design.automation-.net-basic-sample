# Design Automation API Basic Sample
(Formely AutoCAD I/O)

[![.net](https://img.shields.io/badge/.net-4.5-green.svg)](http://www.microsoft.com/en-us/download/details.aspx?id=30653)
[![odata](https://img.shields.io/badge/odata-4.0-yellow.svg)](http://www.odata.org/documentation/)
[![ver](https://img.shields.io/badge/Design%20Automation%20API-2.0-green.svg)](https://developer.autodesk.com/en/docs/design-automation/v2/overview/)
[![visual studio](https://img.shields.io/badge/Visual%20Studio-2012%7C2013%7C2015-blue.svg)](https://www.visualstudio.com/)
[![License](http://img.shields.io/:license-mit-red.svg)](http://opensource.org/licenses/MIT)


## Description

This is the simplest C# client that uses the predefined PlotToPDF activity. It is the sample for the tutorial of design automation API.

## Dependencies

Visual Studio 2012, 2013, 2015.

##Setup/Usage Instructions

* Restore the packages of the project by [NuGet](https://www.nuget.org/). The simplest way is
  * VS2012: Projects tab >> Enable NuGet Package Restore. Then right click the project>>"Manage NuGet Packages for Solution" >> "Restore" (top right of dialog)
  * VS2013/VS2015:  right click the project>>"Manage NuGet Packages for Solution" >> "Restore" (top right of dialog)
* Apply credencials of Design Automation API from https://developer.autodesk.com/. Put your consumer key and secret key in [program.cs](./Program.cs) 
*  Run project, you will see a status in the console:
* if everything works well, the result file (pdf) and the report files will be downloaded at **MyDocuments**.
* if there is any error with the process, check the report file what error is indicated.
* 
Please refer to [Design Automation API v2 API documentation](https://developer.autodesk.com/en/docs/design-automation/v2/overview/).
![thumbnail](help/console.png)

## Questions

Please post your question at our [Forge Support Portal](https://developer.autodesk.com/en/support/get-help).

## License

These samples are licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

## Written by 

Jonathan Miao & Albert Szilvasy
