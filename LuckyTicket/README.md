# Test task "Lucky ticket".

Implement a console application that determines if the ticket number entered by the user is lucky. The ticket number is a number that can be 4 to 8 digits long. 

A ticket is considered lucky if the sum of its first half is equal to the sum of the second half. 

If the user entered a number that contains an odd number of digits, then 0 must be added at the beginning of the ticket number. 

After displaying the result on the screen, the program should wait for the repeated input of the next ticket number from the user. 

To work on the task, you will need to install: 

- __.NET 5__
- One of the code editors Visual Studio Community or VS Code with C# extension 

The source files for the project must be uploaded to a personal Github repository with public access. 

The repository should contain the following files: 

__.gitignore__ with a template from VisualStudio (can be added with dotnet new gitignore command) 

__Program.cs__ – the file with the task code  

__*.csproj__ – the project file created by dotnet new console command 

__run.bat__ – the file with dotnet run command that starts compilation and execution of the program 