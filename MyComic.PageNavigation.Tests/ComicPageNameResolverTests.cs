using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    class ComicPageNameResolverTests
    {
        [TestCase(1,  "01.jpg")]
        [TestCase(9,  "09.jpg")]
        [TestCase(10, "10.jpg")]
        [TestCase(99, "99.jpg")]
        public void GetComicPageNamneFromComicPageNumber_WhenOne_ReturnsCorrectName(int pageNumber, string expectedPageFileName)
        {
            // Arrange
            ComicPageNameResolver comicPageNameResolver = new ComicPageNameResolver();

            // Act
            string pageName = comicPageNameResolver.GetComicPageNamneFromComicPageNumber(pageNumber);

            // Assert
            Assert.That(pageName, Is.EqualTo(expectedPageFileName));
        }
    }
}
