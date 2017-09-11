/// <copyright file="IFileReader.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Input IO interface</summary>
/// 
namespace BlobFinder2.Interfaces
{
    using Models;
    public interface IFileReader
    {
        Field Read(int matrixSize, string Filename); 
    }
}
