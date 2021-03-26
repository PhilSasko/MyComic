using MyComic.PageProviding.DataRetrieval;
using MyComic.Utilities;
using System;
using System.Linq;

namespace MyComic.PageNavigation
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
            _comicIssuePageRetriever = comicIssuePageRetriever ?? throw new ArgumentNullException(nameof(comicIssuePageRetriever));
        }

        public Guid RetrieveNextComicPageId(Guid pageId)
        {
            System.Collections.Generic.IEnumerable<Entities.Comic.ComicPage> comicIssue = 
                _comicIssuePageRetriever.RetrieveComicPagesForIssue(1);

            Entities.Comic.ComicPage currentComicPage = comicIssue.SingleOrDefault(page => page.PageId == pageId);

            if (currentComicPage is null)
            {
                throw new ArgumentException($"Unable to find current comic page for {nameof(pageId)}: {pageId}");
            }

            try
            {
                return comicIssue.TryOffsetBy(page => 
                    page.PageNumber, currentComicPage.PageNumber, idOffset: 1, out Entities.Comic.ComicPage nextComicPage)
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
