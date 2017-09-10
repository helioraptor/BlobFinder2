using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlobFinder2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;

namespace BlobFinder2.Services.Tests
{
    using BlobFinder2.Tests;
    using Models;

   [TestClass()]
    public class GeometryTests
    {
        Geometry CreateGeometry() {
            var logger = new Mock<ILogger>();
            Mock<ILoggerFactory> loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(o => o.CreateLogger(It.IsAny<String>())).Returns(logger.Object);

            Geometry geometry = new Geometry(loggerFactory.Object);

            return geometry;
        }

        [TestMethod()]
        public void RotateDotTest()
        {
            var geometry = CreateGeometry();

            Dot dot = new Dot(3, 5);

            Dot result = geometry.Rotate(dot);

            Assert.AreEqual(4, result.X );
            Assert.AreEqual(3, result.Y);
        }

        [TestMethod()]
        public void RotateFieldTest()
        {
            var geometry = CreateGeometry();

            Field field = ApplicationTests.CreateFieldOriginal();

            var result = geometry.Rotate(field);

            Assert.AreEqual(result.Data[3,3], 0);
            Assert.AreEqual(result.Data[4,4], 1);
        }

        [TestMethod()]
        public void GetDepthTest()
        {
            var geometry = CreateGeometry();

            Field field = ApplicationTests.CreateFieldOriginal();

            int result = geometry.GetDepth(field);

            Assert.AreEqual(1, result);
        }
    }
}