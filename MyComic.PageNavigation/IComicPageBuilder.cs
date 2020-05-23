using MyComic.Entities.Comic;
using System;

namespace MyComic.PageNavigation
{
    public interface IComicPageBuilder
    {
        ComicPage BuildeComicPageFromPageNumber(int pageNumber);
    }

    /* TODO: Restructure to use a comic page navigation context. When we are navigating pages, we do not care about the individual 
     *       page. It doesn't make sense to pass in and return individual pages, when navigating pages, because we always only 
     *       care about the page as it relates to other pages. We might consider a comic page navigation context that has an issue, 
     *       and a current page. (and potentially story archs, series, etc. . Especially when it comes to other creators with their
     *       own intelectual properties) */
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
