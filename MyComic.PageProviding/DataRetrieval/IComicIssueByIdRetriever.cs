using MyComic.Entities.Comic;
using System;

namespace MyComic.PageProviding.DataRetrieval
{
    public interface IComicIssueByIdRetriever
    {
        public ComicIssue GetComicIssue(Guid comicIssueId);
    }
}
