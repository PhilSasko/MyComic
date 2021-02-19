using MyComic.PageProviding.DataRetrieval;
using System;
using System.Linq;

namespace MyComic.PageNavigation
{
    public interface INextComicPageIdRetriever
    {
        Guid RetrieveNextComicPageId(Guid pageId);
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

            try
            {
                Entities.Comic.ComicPage currentComicPage = comicIssue.Single(page => page.PageId == pageId);
                Entities.Comic.ComicPage nextComicPage = comicIssue.Single(page => page.PageNumber == currentComicPage.PageNumber + 1);
                
                return nextComicPage.PageId;
            }
            catch (InvalidOperationException)
            {
                throw new ArgumentException($"Unable to retrieve next comic page for page with PageId {pageId}");
            }

        }
    }
}
