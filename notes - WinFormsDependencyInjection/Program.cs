

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace notes___WinFormsDependencyInjection
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //build interface ConsoleLogger with injection services
            IHost host = CreateHostBuilder().Build();
            ServiceProviderField = host.Services;
            //instead of creating new form, request ServiceProvider to create form 1 with provided services
            // in hostBuilder() configerServices (provided interface)
            Application.Run(ServiceProviderField.GetRequiredService<Form1>() );
        }
        
        //field
        public static IServiceProvider ServiceProviderField { get; private set; }    

        //DI builder interface with ConsoleLogger class getting injection?
        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           //add Ilogger Consolelogger to a created form1
                           services.AddTransient<ILogger, ConsoleLogger>();
                           services.AddTransient<Form1>();
                       });
        }
    }

    public interface ILogger
    {
        void Log(string message);
    }

    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Debug.WriteLine(message);
        }
    }

    //Documentation for DI here
    //https://stackoverflow.com/questions/70475830/how-to-use-dependency-injection-in-winforms
}