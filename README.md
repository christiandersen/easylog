# easylog
A .NET Standard 2.0 library filelogger which logs in files and places them in c:\temp. The naming of the file is the name of the calling assembly with the extension log. Created because of the need of simple file logging, while putting products into production, to reduce doubts about correct configuration and whether other systems are running properly and are configured correctly.

There is defined 3 log levels: Debug, Information and Error.

Can be installed by calling:
Install-Package ChristiAndersen.Easylog

When added to your project, you can write the below using statement and start logging.

using ChristiAndersen.EasyLog;

And then it is ready to log like this in your code:

  Log.Information("Write some log information to the file");
  
  Log.Debug("Write some "¤#()"#¤=(" debug information to the file");
  
  Log.Error("Write some error information to the file");
  
  Log.Information("Write some more log information ot the file");
  
The file output will be:

  2019-11-13 14:11:23.033 [Information] Write some log information to the file
  
  2019-11-13 14:11:23.036 [Debug] Write some "¤#()"#¤=(" debug information to the file
 
  2019-11-13 14:11:23.036 [Error] Write some error information to the file
  
  2019-11-13 14:11:23.037 [Information] Write some more log information ot the file
