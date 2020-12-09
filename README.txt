Hello! This is a comparer for XML config files.
Specify 2 folders in which configuration files can be located. The program compares ALL configuration files and looks for records with the same settings, but different values, and outputs them to the log file.

Lets's start!

1. Open 'ConfigComparer.dll.config' file and change keys 'CloudProjectPath'and 'LoyaltyProjectPath' with your projects paths
   (you can specify the root folder - the program looks for files needed for comparison in all subfolders).
2. Also you can change search file and path for your logging file in keys 'SearchFile' and 'LoggerPath', respectively.
3. Now, after all your changes, run 'ConfigComparer.exe'.
4. Result of your comparing you can see in the logging file.

That's all!
Enjoy :)