/// <copyright file="Geometry.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Geometry calculation service</summary>
/// 
namespace BlobFinder2.Services
{
    using System;
    using Microsoft.Extensions.Logging;
    using Models;
    using Interfaces;
    public class Geometry : BaseService<Geometry>, IGeometry
    {
        private readonly int MatrixSize = 10;

        public Geometry(ILoggerFactory loggerFactory):base(loggerFactory)
        {
        }

        protected int[,] Rotate(int[,] data)
        {
            int[,] result = new int[MatrixSize, MatrixSize];
            for (int x = 0; x != MatrixSize; x++)
            {
                for (int y = 0; y != MatrixSize; y++)
                {
                    Dot a = new Dot(x, y);
                    Dot b = Rotate(a);
                    result[b.Y, b.X] = data[a.Y, a.X];
                }
            }
            return result;
        }

        public Dot Rotate(Dot dot)
        {
            logger.LogInformation("rotating dot");

            Dot result = new Dot();
            result.X = MatrixSize - dot.Y - 1;
            result.Y = dot.X;
            return result;
        }

        public Field Rotate(Field field)
        {
            logger.LogInformation("rotating field");

            Field result = new Field();

            result.Data = this.Rotate(field.Data);

            result.VisitedCells = this.Rotate(field.VisitedCells);

            foreach (Dot dot in field.DiscoveredDots)
            {
                result.DiscoveredDots.Add(this.Rotate(dot));
            }

            result.TotalReadCount = field.TotalReadCount;

            return result;
        }

        public int GetDepth(Field field)
        {
            logger.LogInformation("calculating depth");

            int y = 0;
            while (y < MatrixSize)
            {
                for (int x = 0; x != MatrixSize; x++)
                {
                    foreach (Dot d in field.DiscoveredDots)
                    {
                        if (d.Y <= y)
                        {
                            //one of found dot is also topmost in this direction
                            return d.Y;
                        }
                    }
                    if (field.VisitedCells[y, x] == 0)
                    {
                        ///read
                        int i = field.Data[y, x];
                        field.TotalReadCount++;
                        field.VisitedCells[y, x] = 1;
                        if (i == 1)
                        {//found!
                            Dot result = new Dot(x, y);
                            field.DiscoveredDots.Add(result);
                            return result.Y;
                        }
                    }
                }
                y++;
            }
            throw new Exception("can not find any dots");
        }

        public int GetMatrixSize()
        {
            return MatrixSize;
        }
    }
}
