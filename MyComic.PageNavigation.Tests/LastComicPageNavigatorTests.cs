using MyComic.Entities.Comic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    class LastComicPageNavigatorTests
    {
        private IComicPageBuilder _comicPageBuilder;

        [Test]
        public void LastComicPage_WhenFirstComicPage_GetsLastPage()
        {
            ILastComicPageNavigator lastComicPageNavigator = new LastComicPageNavigator();
            ComicPage firstComicPage = new ComicPage() 
            { 
                PageNumber = 1,
                ComicIssue = new ComicIssue() { NumberOfPages = 32 }
            };
            ComicPage lastComicPage = lastComicPageNavigator.LastComicPage(firstComicPage);

        }

        [SetUp]
        public void Setup()
        {
            _comicPageBuilder = new ComicPageBuilder(new ComicPageNameResolver());
        }
    }
}
