using MyComic.Entities.Comic;
using NUnit.Framework;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    class NextComicPageNavigatorTests
    {
        private IComicPageBuilder _comicPageBuilder;

        [Test]
        public void NextComicPage_WhenPageNumberIs1_Returns2()
        {
            INextComicPageNavigator nextComicPageNavigator = new NextComicPageNavigator(_comicPageBuilder);
            ComicPage comicPage = new ComicPage() { PageNumber = 1 };

            ComicPage nextComicPage = nextComicPageNavigator.GetNextComicPage(comicPage);

            Assert.That(nextComicPage.PageNumber, Is.EqualTo(2));
        }

        [SetUp]
        public void Setup()
        {
            _comicPageBuilder = new ComicPageBuilder(new ComicPageNameResolver());
        }
    }
}
