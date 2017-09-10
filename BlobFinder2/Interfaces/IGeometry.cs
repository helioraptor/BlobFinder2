using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFinder2.Interfaces
{
    using Models;
    public interface IGeometry
    {
        int GetMatrixSize();
        
        Field Rotate(Field field);
        Dot Rotate(Dot dot);
        int GetDepth(Field field);
    }
}
