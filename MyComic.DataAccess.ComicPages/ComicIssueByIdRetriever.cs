using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComic.DataAccess.ComicPages
{
    public class ComicIssueByIdRetriever : IComicIssueByIdRetriever
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public ComicIssueByIdRetriever(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever ?? throw new ArgumentNullException(nameof(comicIssuePageRetriever));
        }

        public ComicIssue GetComicIssue(Guid comicIssueId)
        {
            IEnumerable<ComicPage> comicPages = _comicIssuePageRetriever.RetrieveComicPagesForIssue(1);
            return new ComicIssue()
            {
                IssueId = new Guid("075b6e68-9d2f-476f-9e92-1e8e4b870f8e"),
                NumberOfPages = comicPages.Count(),
                IssueNumber = 1,
                Pages = comicPages
            };
        }
    }
}
