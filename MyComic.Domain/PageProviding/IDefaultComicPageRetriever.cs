using MyComic.Domain.PageProviding.DataRetrieval;
using MyComic.Domain.Entities.Comic;

namespace MyComic.Domain.PageProviding
{
    public interface IDefaultComicPageRetriever
    {
        ComicPage RetrieveDefaultComicPage();
    }

    public class DefaultComicPageRetriever : IDefaultComicPageRetriever
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public DefaultComicPageRetriever(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever;
        }

        public ComicPage RetrieveDefaultComicPage()
        {
            try
            {
                return _comicIssuePageRetriever.RetrieveComicPagesForIssue(1).Single(page => page.PageNumber == 0);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Unable to retrieve default comic page");
            }
        }
    }
}
