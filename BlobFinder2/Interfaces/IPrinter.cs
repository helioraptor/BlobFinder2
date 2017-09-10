using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlobFinder2.Interfaces
{
    using Models;
    public interface IPrinter
    {
        void Print(Field field);

        void Print(Result result);
    }
}
