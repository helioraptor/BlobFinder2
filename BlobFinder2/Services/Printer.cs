/// <copyright file="Printer.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Console IO service</summary>
/// 
namespace BlobFinder2.Services
{
    using System;
    using Microsoft.Extensions.Logging;
    using Models;
    using Interfaces;
    public class Printer : BaseService<Printer>, IPrinter
    {
        public Printer(ILoggerFactory loggerFactory):base(loggerFactory)
        {
        }
        public void Print(Field field)
        {
            for (int y = 0; y != 10; y++)
            {
                for (int x = 0; x != 10; x++)
                {
                    Boolean found = false;
                    foreach (Dot dot in field.DiscoveredDots)
                    {
                        if ((dot.X == x) && (dot.Y == y))
                        {
                            Console.Write('*');
                            found = true;
                            break;
                        }
                    }

                    if (!found && field.VisitedCells[y, x] == 1)
                    {
                        Console.Write('o');
                        found = true;
                    }

                    if (!found)
                    {
                        Console.Write(field.Data[y, x]);
                    }
                    Console.Write(",");
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }
        public void Print(Result result)
        {
            Console.Write("Cell Reads: "+ result.CellReads + "\n");
            Console.Write("Top:"+ result.Top + "\n");
            Console.Write("Left:"+ result.Left + "\n");
            Console.Write("Bottom:"+ result.Bottom + "\n");
            Console.Write("Right:"+ result.Right + "\n");
        }
    }
}
