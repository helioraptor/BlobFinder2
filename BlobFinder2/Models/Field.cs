using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFinder2.Models
{
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
