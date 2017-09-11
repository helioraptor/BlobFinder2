/// <copyright file="FileReader.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>File IO service</summary>
/// 
namespace BlobFinder2.Services
{
    using System.IO;
    using Microsoft.Extensions.Logging;
    using Models;
    using Interfaces;

    public class FileReader : BaseService<FileReader>, IFileReader
    {
        public FileReader(ILoggerFactory loggerFactory):base(loggerFactory)
        {
        }

        public Field Read(int matrixSize, string filename)
        {
            logger.LogInformation("reading matrix size {0} from {1}", matrixSize, filename);

            int[,] result = new int[matrixSize, matrixSize];
            int row = 0;
            using (var reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    for (int column= 0; column != values.Length; column++)
                    {
                        result[row, column] = int.Parse(values[column]);
                    }
                    row++;
                }
            }
            return new Field(result);
        }
    }
}
