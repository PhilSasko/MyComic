using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageProviding.DataRetrieval
{
    public interface IComicIssuePageRetriever
    {
        IEnumerable<ComicPage> RetrieveComicPagesForIssue(int comicIssueNumber);
    }
}
