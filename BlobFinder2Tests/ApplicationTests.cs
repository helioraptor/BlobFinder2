using Microsoft.VisualStudio.TestTools.UnitTesting;
using BlobFinder2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;

namespace BlobFinder2.Tests
{
    using Interfaces;
    using Services;
    using Models;


    [TestClass()]
    public class ApplicationTests
    {
        public static Field CreateFieldOriginal() {
            int[,] data = {{0,0,0,0,0,0,0,0,0,0}
                       ,{0,0,1,1,1,0,0,0,0,0}
                       ,{0,0,1,1,1,1,1,0,0,0}
                       ,{0,0,1,0,0,0,1,0,0,0}
                       ,{0,0,1,1,1,1,1,0,0,0}
                       ,{0,0,0,0,1,0,1,0,0,0}
                       ,{0,0,0,0,1,0,1,0,0,0}
                       ,{0,0,0,0,1,1,1,0,0,0}
                       ,{0,0,0,0,0,0,0,0,0,0}
                       ,{0,0,0,0,0,0,0,0,0,0}};

            return new Field(data);
        }

        Field CreateFieldFull()
        {
            int[,] data = {{0,0,1,0,0,0,0,0,0,0}
                       ,{0,0,1,1,1,0,0,0,0,0}
                       ,{0,0,1,1,1,1,1,0,0,0}
                       ,{0,0,1,0,0,0,1,0,0,0}
                       ,{1,1,1,1,1,1,1,0,0,0}
                       ,{0,0,0,0,1,0,1,1,1,1}
                       ,{0,0,0,0,1,0,1,0,0,0}
                       ,{0,0,0,0,1,1,1,0,0,0}
                       ,{0,0,0,0,0,1,0,0,0,0}
                       ,{0,0,0,0,0,1,0,0,0,0}};

            return new Field(data);
        }

        Application CreaateApplication() {
            Mock<IFileReader> fileReader = new Mock<IFileReader>();
            fileReader.Setup(o => o.Read(It.IsAny<int>(), It.IsAny<string>())).Returns((int size, string filename) =>
            {
                return CreateFieldOriginal();
            });

            Mock<IPrinter> printer = new Mock<IPrinter>();
            printer.Setup(o => o.Print(It.IsAny<Result>())).Callback((Result result) =>
            {
                Assert.AreEqual(result.Top, 333);
            });

            var logger = new Mock<ILogger>();
            Mock<ILoggerFactory> loggerFactory = new Mock<ILoggerFactory>();
            loggerFactory.Setup(o => o.CreateLogger(It.IsAny<String>())).Returns(logger.Object);

            var geometry = new Geometry(loggerFactory.Object);

            // Action
            Application application = new Application(fileReader.Object, loggerFactory.Object, geometry, printer.Object);

            return application;
        }


        [TestMethod()]
        public void ReadFileTest()
        {
            var application = CreaateApplication();

            var field = application.ReadFile("some file name");

            Assert.AreEqual(field.Data[0, 0] , 0);
            Assert.AreEqual(field.Data[2, 2] , 1);
        }

        [TestMethod()]
        public void CalculateBordersOriginalTest()
        {
            var application = CreaateApplication();

            var field = CreateFieldOriginal();

            var result = application.CalculateBorders(field);

            Assert.AreEqual(1, result.Top);
            Assert.AreEqual(2, result.Left);
            Assert.AreEqual(7, result.Bottom);
            Assert.AreEqual(6, result.Right);
            Assert.IsTrue(result.CellReads <= 44);
        }

        [TestMethod()]
        public void CalculateBordersFullTest()
        {
            var application = CreaateApplication();

            var field = CreateFieldFull();

            var result = application.CalculateBorders(field);

            Assert.AreEqual(0, result.Top);
            Assert.AreEqual(0, result.Left);
            Assert.AreEqual(9, result.Bottom);
            Assert.AreEqual(9, result.Right);

            Assert.IsTrue(result.CellReads <= 44);
        }

        [TestMethod()]
        public void PrintResultsTest()
        {
            var application = CreaateApplication();

            var result = new Result();

            result.Top = 333;

            application.PrintResults(result);
        }
    }
}