using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComic.DataAccess.ComicPages
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
            _comicIssuePageRetriever = comicIssuePageRetriever ?? throw new ArgumentNullException(nameof(comicIssuePageRetriever));
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
