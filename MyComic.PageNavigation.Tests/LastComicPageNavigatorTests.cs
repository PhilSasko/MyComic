using MyComic.Entities.Comic;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    class LastComicPageNavigatorTests
    {
        private IComicPageBuilder _comicPageBuilder;

        [TestCase(32, 32, "32.jpg")]
        [TestCase(10, 10, "10.jpg")]
        [TestCase(9, 9, "09.jpg")]
        [TestCase(1, 1, "01.jpg")]
        public void LastComicPage_WhenFirstComicPage_GetsLastPage(int numberOfPages, int lastPageNumber, string lastPageFileName)
        {
            // Should we be using the ServiceLocator (antis) pattern in a case like this?
            IComicPageNameResolver comicPageNameResolver = new ComicPageDoubleDigitNumberNameResolver();
            IComicPageBuilder comicPageBuilder = new ComicPageBuilder(comicPageNameResolver);
            ILastComicPageNumberResolver lastComicPageNumberResolver = new LastComicPageNumberResolver();
            
            ILastComicPageNavigator lastComicPageNavigator = new LastComicPageNavigator(comicPageBuilder, lastComicPageNumberResolver);

            ComicIssue comicIssue = new ComicIssue()
            {
                NumberOfPages = numberOfPages
            };

            ComicPage lastComicPage = lastComicPageNavigator.GetLastComicPage(comicIssue);

            Assert.That(lastComicPage.PageNumber, Is.EqualTo(lastPageNumber));
            Assert.That(lastComicPage.FileName, Is.EqualTo(lastPageFileName));
        }

        [SetUp]
        public void Setup()
        {
            _comicPageBuilder = new ComicPageBuilder(new ComicPageDoubleDigitNumberNameResolver());
        }
    }
}
