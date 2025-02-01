using MyComic.Domain.Entities.Comic;

namespace MyComic.Domain.PageProviding.DataRetrieval
{
    public interface IComicIssueByIdRetriever
    {
        public ComicIssue GetComicIssue(Guid comicIssueId);
    }
}
