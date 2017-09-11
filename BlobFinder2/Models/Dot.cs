/// <copyright file="Dot.cs" company="epam.com">
///     Epam.com. All rights reserved.
/// </copyright>
/// <author>Andrey Zorin</author>
/// <summary>Single Dot POCO</summary>
/// 
namespace BlobFinder2.Models
{
    public class Dot
    {
        public int X;
        public int Y;
        public Dot() { }
        public Dot(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
