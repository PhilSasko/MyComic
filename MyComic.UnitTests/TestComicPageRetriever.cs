using MyComic.Domain.Retrievers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyComic.UnitTests
{
    [TestFixture]
    public class TestComicPageRetriever
    {
        [Test]
        public void TestRetrieve_WhenPage01_ReturnsCorrectFullPath()
        {
            // Arrange
            LocalFilePathRetriever filePathRetriever = new LocalFilePathRetriever();
            ComicPageNameResolver resolver = new ComicPageNameResolver(filePathRetriever);

            // Act
            string fullPath = resolver.Resolve(1);

            // Assert
            Assert.That(fullPath, Is.EqualTo(@"C:\Users\sasko\source\repos\MyComic\_images\01.jpg"));
        }
    }
}
