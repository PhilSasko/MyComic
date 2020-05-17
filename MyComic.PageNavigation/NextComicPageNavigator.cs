using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation
{
    public interface INextComicPageNavigator
    {
        ComicPage GetNextComicPage(ComicPage currentComicPage);
    }

    public class NextComicPageNavigator : INextComicPageNavigator
    {
        private readonly IComicPageBuilder _comicPageBuilder;

        public NextComicPageNavigator(IComicPageBuilder comicPageBuilder)
        {
            _comicPageBuilder = comicPageBuilder ?? throw new ArgumentNullException(nameof(comicPageBuilder));
        }

        public ComicPage GetNextComicPage(ComicPage currentComicPage)
        {
            int pageNumber = currentComicPage.PageNumber;
            int nextPageNumber = pageNumber + 1;
            return _comicPageBuilder.BuildeComicPageFromPageNumber(nextPageNumber);
        }
    }
}
