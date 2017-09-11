/// <copyright file="Program.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Blob application entry point</summary>

namespace BlobFinder2
{
    using System;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using Interfaces;
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
