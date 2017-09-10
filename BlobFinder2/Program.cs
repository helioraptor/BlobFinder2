using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace BlobFinder2
{
    using Interfaces;
    using Models;
    using Services;

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1) {
                Console.WriteLine("usage: {0} [filename]", Environment.GetCommandLineArgs()[0]);
                return;
            }
            
            IServiceCollection serviceCollection = new ServiceCollection();

            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<Application>().Run(args[0]);
        }

        static private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IFileReader, FileReader>();
            serviceCollection.AddSingleton<IPrinter, Printer>();
            serviceCollection.AddSingleton<IGeometry, Geometry>();

            ILoggerFactory loggerFactory = new LoggerFactory().AddConsole();
            serviceCollection.AddSingleton(loggerFactory); 
            serviceCollection.AddLogging(); 

            serviceCollection.AddTransient<Application>();
        }
    }
}
