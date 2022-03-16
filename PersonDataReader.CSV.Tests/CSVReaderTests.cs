using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace PersonDataReader.CSV.Tests
{
    [TestClass]
    public class CSVReaderTests
    {
        [TestMethod]
        public void GetPeople_WithGoodRecords_ReturnAllRecords()
        {
            // Arrange
            var reader = new CSVReader();
            reader.FileLoader = new FakeFileLoader("Good");

            // Act
            var result = reader.GetPeople();

            //Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetPeople_WithNoFile_ThrowsFileNotFoundException()
        {
            var reader = new CSVReader();

            Assert.ThrowsException<FileNotFoundException>(() => reader.GetPeople());
        }

        [TestMethod]
        public void GetPeople_WithSomeBadRecords_ReturnGoodRecords()
        {
            // Arrange
            var reader = new CSVReader();
            reader.FileLoader = new FakeFileLoader("Mixed");

            // Act
            var result = reader.GetPeople();

            //Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void GetPeople_WithOnlyBadRecords_ReturnEmptyList()
        {
            // Arrange
            var reader = new CSVReader();
            reader.FileLoader = new FakeFileLoader("Bad");

            // Act
            var result = reader.GetPeople();

            //Assert
            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetPeople_WithEmptyFile_ReturnEmptyList()
        {
            // Arrange
            var reader = new CSVReader();
            reader.FileLoader = new FakeFileLoader("Empty");

            // Act
            var result = reader.GetPeople();

            //Assert
            Assert.AreEqual(0, result.Count());
        }
    }
}
