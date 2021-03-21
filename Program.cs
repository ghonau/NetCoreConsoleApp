using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.IO;

// DI, Serilog, Settings 

namespace ConsoleUI
{
    partial class Program
    {    

        static void Main(string[] args)
        {
            var host = Startup.Start();
            host.Services.GetRequiredService<IGreetingService>().Run(); 
        }   
        

    }    
}
