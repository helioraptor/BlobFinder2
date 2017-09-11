/// <copyright file="IGeometry.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Geometry service interface</summary>
/// 
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
