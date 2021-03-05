using MyComic.PageProviding.DataRetrieval;
using MyComic.Utilities;
using System;
using System.Linq;

namespace MyComic.PageNavigation
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
            _comicIssuePageRetriever = comicIssuePageRetriever ?? throw new ArgumentNullException(nameof(comicIssuePageRetriever));
        }

        public Guid RetrievePreviousComicPageId(Guid pageId)
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
                    page.PageNumber, currentComicPage.PageNumber, idOffset: -1, out Entities.Comic.ComicPage previousComicPage)
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
