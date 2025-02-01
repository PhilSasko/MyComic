using MyComic.Domain.PageProviding.DataRetrieval;
using MyComic.Domain.Entities.Comic;

namespace MyComic.Domain.PageProviding
{
    public interface IComicIssueResolver
    {
        ComicIssue ResolveComicIssue(int comicIssueNumber);
    }

    public class ComicIssueResolver : IComicIssueResolver
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public ComicIssueResolver(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever;
        }

        public ComicIssue ResolveComicIssue(int comicIssueNumber)
        {
            IEnumerable<ComicPage> comicPages = _comicIssuePageRetriever.RetrieveComicPagesForIssue(comicIssueNumber);
            return new ComicIssue() { NumberOfPages = 32, IssueNumber = comicIssueNumber, Pages = comicPages };
        }
    }
}
