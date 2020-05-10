using System.Text;

namespace MyComic.PageNavigation
{
    public  interface IComicPageNameResolver
    {
        string GetComicPageNamneFromComicPageNumber(int comicPageNumber);
    }
    public class ComicPageNameResolver : IComicPageNameResolver
    {
        // TODO: create a test for this.
        public string GetComicPageNamneFromComicPageNumber(int comicPageNumber)
        {
            StringBuilder pageName = new StringBuilder(comicPageNumber < 10 ? $"0{comicPageNumber}" : $"{comicPageNumber}");
            return pageName.Append(".jpg").ToString();

            // TODO: considering having the extension be resolved at runtime
        }
    }
}