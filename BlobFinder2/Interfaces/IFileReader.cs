using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlobFinder2.Models;

namespace BlobFinder2.Interfaces
{
    public interface IFileReader
    {
        Field Read(int matrixSize, string Filename); 
    }
}
