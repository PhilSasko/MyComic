using MyComic.Domain.Entities.Comic;

namespace MyComic.Domain.PageProviding.DataRetrieval
{
    public interface IComicIssuePageRetriever
    {
        IEnumerable<ComicPage> RetrieveComicPagesForIssue(int comicIssueNumber);
    }
}
