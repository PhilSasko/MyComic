using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;
using MyComic.Utilities;

namespace MyComic.Domain.PageNavigation
{
    public interface IPreviousComicPageIdRetriever
    {
        Guid RetrievePreviousComicPageId(Guid currentPageId);
    }

    public class PreviousComicPageIdRetriever : IPreviousComicPageIdRetriever
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public PreviousComicPageIdRetriever(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever;
        }

        public Guid RetrievePreviousComicPageId(Guid pageId)
        {
            IEnumerable<ComicPage> comicIssue =
                _comicIssuePageRetriever.RetrieveComicPagesForIssue(1);

            ComicPage currentComicPage = comicIssue.SingleOrDefault(page => page.PageId == pageId) 
                ?? throw new ArgumentException($"Unable to find current comic page for {nameof(pageId)}: {pageId}");

            try
            {
                return comicIssue.TryOffsetBy(page =>
                    page.PageNumber, currentComicPage.PageNumber, idOffset: -1, out ComicPage previousComicPage)
                    ? previousComicPage.PageId
                    : currentComicPage.PageId;
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Unable to retrieve previous comic page for page with PageId {pageId}");
            }
        }
    }
}
