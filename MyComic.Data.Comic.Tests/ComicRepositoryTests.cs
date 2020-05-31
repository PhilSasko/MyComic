using MyComic.Data.Comic.Dtos;
using MyComic.Files;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Data.Comic.Tests
{
    [TestFixture]
    public class ComicRepositoryTests
    {
        [Test]
        public void GetComicPage_WhenFirstComicPageSpecified_ReturnsFirstComicaPage()
        {
            IFileStringResolver fileStringResolver = new FileStringResolver();
            IComicPageRepository comicPageRepository = new ComicPageRepository(fileStringResolver);
            Guid comicPageId = new Guid("11111111-1111-1111-1111-111111111111");
            ComicPage firstComicPage = comicPageRepository.GetComicPage(c => c.ComicPageId == comicPageId);
            int comicPageNumber = 1;
            Assert.That(firstComicPage.PageNumber, Is.EqualTo(comicPageNumber));
        }
    }
}
