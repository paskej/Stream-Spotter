Team Name: 404 Brain Not Found
Project Name: Stream Spotter
Team Members: Jack Morgan, Ben McKee, Joe Paske, Bryce Brennan

Build Instructions: Stream Spotter uses .NET Core 3, and should be opened in Visual Studio 19 for easiest use. To build an .exe of the
program, navigate to "Build" -> "Configuration Manager" and change "Active solution conficuration" to "Release". Build the program, then
navigate to ".\StreamSpotter\StreamSpotter\bin\Release". You should see a .exe file in this folder. You can delete the Debug folder if it
is in the bin folder, and can then move the bin folder anywhere in your file system.

Known bugs:
*When in the movie screen, if the program is in it's smallest state, the title and description may not be formatted correctly.
 This stayed like this because we did not have enough time to adjust the formatting, and

Design Deficiency:
*Cannot use both sets of filters at the same time
*Program assumes the user is connected to the internet and does not check if they are not.