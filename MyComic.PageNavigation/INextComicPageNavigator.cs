using MyComic.Entities.Comic;

namespace MyComic.PageNavigation
{
    public interface INextComicPageNavigator
    {
        ComicPage GetNextPage(ComicPage comicPage);
    }

    // TODO: get rid of this class
    public class NextComicPageNavigator : INextComicPageNavigator
    {
        private readonly IComicPageNameResolver _comicPageNameResolver;
        public ComicPage GetNextPage(ComicPage comicPage)
        {
            // TODO: Use Ioc
            ComicPageNameResolver comicPageNameResolver = new ComicPageNameResolver();
            int newComicPageNumber = comicPage.PageNumber + 1;
            string comicPageFileName = comicPageNameResolver.GetComicPageNamneFromComicPageNumber(newComicPageNumber);
            comicPage.FileName = comicPageFileName;
            return comicPage;
        }
    }
}
