using MyComic.Entities.Comic;

namespace MyComic.PageProviding
{
    public interface IDefaultComicPageRetriever
    {
        ComicPage RetrieveDefaultComicPage();
    }

    public class DefaultComicPageRetriever : IDefaultComicPageRetriever
    {
        public ComicPage RetrieveDefaultComicPage()
        {
            return new ComicPage()
            {
                PageNumber = 0,
                FileName = "cover.jpg",
                IssueId = 1
            };
        }
    }
}
