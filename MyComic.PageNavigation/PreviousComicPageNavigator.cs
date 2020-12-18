using MyComic.Entities.Comic;
using MyComic.PageProviding;
using System;

namespace MyComic.PageNavigation
{
    public interface IPreviousComicPageNavigator
    {
        ComicPage GetPreviousComicPage(ComicPage currentComicPage);
    }

    public class PreviousComicPageNavigator : IPreviousComicPageNavigator
    {
        private readonly IComicPageBuilder _comicPageBuilder;

        public PreviousComicPageNavigator(IComicPageBuilder comicPageBuilder)
        {
            _comicPageBuilder = comicPageBuilder ?? throw new ArgumentNullException(nameof(comicPageBuilder));
        }

        public ComicPage GetPreviousComicPage(ComicPage currentComicPage)
        {
            int pageNumber = currentComicPage.PageNumber;
            int PreviousPageNumber = pageNumber > 0 ? pageNumber - 1 : 0;
            return _comicPageBuilder.BuildeComicPageFromPageNumber(PreviousPageNumber);
        }
    }
}
