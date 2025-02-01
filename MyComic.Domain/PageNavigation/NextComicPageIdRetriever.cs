using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;
using MyComic.Utilities;

namespace MyComic.Domain.PageNavigation
{
    public interface INextComicPageIdRetriever
    {
        Guid RetrieveNextComicPageId(Guid currentPageId);
    }
    public class NextComicPageIdRetriever : INextComicPageIdRetriever
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public NextComicPageIdRetriever(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever;
        }

        public Guid RetrieveNextComicPageId(Guid pageId)
        {
            IEnumerable<ComicPage> comicIssue =
                _comicIssuePageRetriever.RetrieveComicPagesForIssue(1);

            ComicPage currentComicPage = comicIssue.SingleOrDefault(page => page.PageId == pageId)
                ?? throw new ArgumentException($"Unable to find current comic page for {nameof(pageId)}: {pageId}");

            try
            {
                return comicIssue.TryOffsetBy(page =>
                    page.PageNumber, currentComicPage.PageNumber, idOffset: 1, out ComicPage nextComicPage)
                    ? nextComicPage.PageId
                    : currentComicPage.PageId;
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Unable to retrieve next comic page for page with PageId {pageId}");
            }
        }
    }
}
