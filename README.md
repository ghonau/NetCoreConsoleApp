# NetCoreConsoleApp
Console app with DI, logger and appsetting configuration 
Just a skelton and initial configuration of .net core console application showing how to configura built-in DI, Serilog logger and appsettings configuration for console application
For some entity framework override function https://github.com/itsdevkev/TaskList

If you want to migration shema changes to migrations folder in another project
if you are in the startup project folder using powershell console
you might be able to run the command as follows 


dotnet ef migrations add CreateMigration --startup-project ./ --project ../{your project name with migrations folder}/  
![image](https://user-images.githubusercontent.com/4524047/112213086-a6a3ab00-8c6d-11eb-8054-009613be4315.png)


dotnet ef database update --startup-project ./ --project ../{your project name with migrations folder}/  
![image](https://user-images.githubusercontent.com/4524047/112213860-76104100-8c6e-11eb-9f11-ac0af6a8142d.png)

  


