using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System;
using System.Linq;

namespace MyComic.PageProviding
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
            _comicIssuePageRetriever = comicIssuePageRetriever ?? throw new ArgumentNullException(nameof(comicIssuePageRetriever));
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
