using MyComic.Entities.Comic;
using MyComic.PageProviding;
using NUnit.Framework;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    class PreviousComicPageNavigatorTests
    {
        private IComicPageBuilder _comicPageBuilder;

        [Test]
        public void PreviousComicPage_WhenPageNumberIs2_Returns1()
        {
            IPreviousComicPageNavigator PreviousComicPageNavigator = new PreviousComicPageNavigator(_comicPageBuilder);
            ComicPage comicPage = new ComicPage() { PageNumber = 2 };

            ComicPage PreviousComicPage = PreviousComicPageNavigator.GetPreviousComicPage(comicPage);

            Assert.That(PreviousComicPage.PageNumber, Is.EqualTo(1));
        }

        [Test]
        public void PreviousComicPage_WhenPageNumberIs0_Returns0()
        {
            IPreviousComicPageNavigator PreviousComicPageNavigator = new PreviousComicPageNavigator(_comicPageBuilder);
            ComicPage comicPage = new ComicPage() { PageNumber = 0 };

            ComicPage PreviousComicPage = PreviousComicPageNavigator.GetPreviousComicPage(comicPage);

            Assert.That(PreviousComicPage.PageNumber, Is.EqualTo(0));
        }

        [SetUp]
        public void Setup()
        {
            _comicPageBuilder = new ComicPageBuilder(new ComicPageDoubleDigitNumberNameResolver());
        }
    }
}
