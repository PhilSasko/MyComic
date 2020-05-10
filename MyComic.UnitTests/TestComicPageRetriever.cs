using MyComic.PageNavigation;
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
        // TODO: use one test project per thing
        [Test]
        public void TestRetrieve_WhenPage01_ReturnsCorrectFullPath()
        {
            // Arrange
            ComicPageNameResolver resolver = new ComicPageNameResolver();

            // Act
            string fullPath = resolver.GetComicPageNamneFromComicPageNumber(1);

            // Assert
            Assert.That(fullPath, Is.EqualTo(@"C:\Users\sasko\source\repos\MyComic\_images\01.jpg"));
        }
    }
}
