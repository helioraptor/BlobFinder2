/// <copyright file="Field.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Field configuration POCO</summary>
/// 
namespace BlobFinder2.Models
{
    using System.Collections.Generic;
    public class Field
    {
        public int[,] Data;
        public int[,] VisitedCells;
        public List<Dot> DiscoveredDots = new List<Dot>();
        public int TotalReadCount = 0;

        public Field() { }
        public Field(int[,] data)
        {
            this.Data = data;
            this.VisitedCells = new int[data.Length, data.Length]; //default 0
        }
    }
}
