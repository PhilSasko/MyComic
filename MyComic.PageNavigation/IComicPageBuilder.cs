using MyComic.Entities.Comic;
using System;

namespace MyComic.PageNavigation
{
    public interface IComicPageBuilder
    {
        ComicPage BuildeComicPageFromPageNumber(int pageNumber);
    }

    public class ComicPageBuilder : IComicPageBuilder
    {
        private readonly IComicPageNameResolver _comicPageNameResolver;

        public ComicPageBuilder(IComicPageNameResolver comicPageNameResolver)
        {
            _comicPageNameResolver = comicPageNameResolver ?? throw new ArgumentNullException(nameof(comicPageNameResolver));
        }

        public ComicPage BuildeComicPageFromPageNumber(int pageNumber)
        {
            string comicPageName = _comicPageNameResolver.GetComicPageNamneFromComicPageNumber(pageNumber);
            return new ComicPage()
            {
                PageNumber = pageNumber,
                FileName = comicPageName
            };
        }
    }
}
