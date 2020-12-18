using MyComic.PageProviding;
using NUnit.Framework;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    class ComicPageDoubleDigitNumberNameResolverTests
    {
        [TestCase(1,  "01.jpg")]
        [TestCase(9,  "09.jpg")]
        [TestCase(10, "10.jpg")]
        [TestCase(99, "99.jpg")]
        public void GetComicPageNamneFromComicPageNumber_WhenOne_ReturnsCorrectName(int pageNumber, string expectedPageFileName)
        {
            // Arrange
            ComicPageDoubleDigitNumberNameResolver comicPageNameResolver = new ComicPageDoubleDigitNumberNameResolver();

            // Act
            string pageName = comicPageNameResolver.GetComicPageNamneFromComicPageNumber(pageNumber);

            // Assert
            Assert.That(pageName, Is.EqualTo(expectedPageFileName));
        }
    }
}
