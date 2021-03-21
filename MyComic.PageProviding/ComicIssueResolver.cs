using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System;
using System.Collections.Generic;

namespace MyComic.PageProviding
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
            _comicIssuePageRetriever = comicIssuePageRetriever ?? throw new ArgumentNullException(nameof(comicIssuePageRetriever));
        }

        public ComicIssue ResolveComicIssue(int comicIssueNumber)
        {
            IEnumerable<ComicPage> comicPages = _comicIssuePageRetriever.RetrieveComicPagesForIssue(comicIssueNumber);
            return new ComicIssue() { NumberOfPages = 32, IssueNumber = comicIssueNumber, Pages = comicPages };
        }
    }
}
