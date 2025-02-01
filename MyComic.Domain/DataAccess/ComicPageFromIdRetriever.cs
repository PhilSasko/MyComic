using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;

namespace MyComic.Domain.DataAccess
{
    public interface IComicPageFromIdRetriever
    {
        ComicPage RetrieveComicPageFromId(Guid pageId);
    }

    public class ComicPageFromIdRetriever : IComicPageFromIdRetriever
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public ComicPageFromIdRetriever(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever;
        }

        public ComicPage RetrieveComicPageFromId(Guid pageId)
        {
            IEnumerable<ComicPage> comicPages = _comicIssuePageRetriever.RetrieveComicPagesForIssue(1); // TODO: Temporary solution. Get page some other way.
            try
            {
                return comicPages.Single(page => page.PageId == pageId);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException($"Unable to find the comic page with PageId {pageId}");
            }
        }
    }
}
