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
    using Services;
    using Models;
    public class Application
    {
        private readonly IFileReader fileReader;
        private readonly ILogger<Application> logger;
        private readonly IGeometry geometry;
        private readonly IPrinter printer;

        public Application(IFileReader fileReader,
                            ILoggerFactory loggerFactory,
                            IGeometry geometry,
                            IPrinter printer)
        {
            this.fileReader = fileReader;
            this.logger = loggerFactory.CreateLogger<Application>();
            this.geometry = geometry;
            this.printer = printer;
        }
        public Field ReadFile(string FileName)
        {
            Field field = fileReader.Read(geometry.GetMatrixSize(), FileName);

            return field;
        }

        public Result CalculateBorders(Field field) {

            Result result = new Result();

            result.Top = geometry.GetDepth(field);

            logger.LogInformation("top:" + result.Top);

            printer.Print(field);

            field = geometry.Rotate(field);

            result.Left = geometry.GetDepth(field);

            logger.LogInformation("right:" + result.Left);

            printer.Print(field);

            field = geometry.Rotate(field);

            result.Bottom = geometry.GetMatrixSize() - 1 - geometry.GetDepth(field);

            logger.LogInformation("bottom:" + result.Bottom);

            printer.Print(field);

            field = geometry.Rotate(field);

            result.Right = geometry.GetMatrixSize() - 1 - geometry.GetDepth(field);

            logger.LogInformation("left:" + result.Right);

            printer.Print(field);

            logger.LogInformation("totalReadCount:" + field.TotalReadCount );

            result.CellReads = field.TotalReadCount;

            return result;
        }

        public void PrintResults(Result result) {

            printer.Print(result);
        }

        public void Run(string filename) {
            try
            {
                logger.LogInformation("Starting application with parameter:{0}",filename);

                var Field = ReadFile(filename);

                var result = CalculateBorders(Field);

                PrintResults(result);
            }
            catch (Exception ex) {
                logger.LogError(ex.Message);
            }
        }
    }
}
