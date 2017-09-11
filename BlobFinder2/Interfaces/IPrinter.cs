/// <copyright file="IPrinter.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Output IO interface</summary>
/// 
namespace BlobFinder2.Interfaces
{
    using Models;
    public interface IPrinter
    {
        void Print(Field field);

        void Print(Result result);
    }
}
