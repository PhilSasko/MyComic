using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComic.PageNavigation
{
    public interface IFirstComicPageIdRetriever
    {
        Guid RetrieveFirstComicPageId(Guid currentComicIssueId);
    }
    public class FirstComicPageIdRetriever : IFirstComicPageIdRetriever
    {
        private readonly IComicIssueByIdRetriever _comicIssueByIdRetriever;

        public FirstComicPageIdRetriever(IComicIssueByIdRetriever comicIssueByIdRetriever)
        {
            _comicIssueByIdRetriever = comicIssueByIdRetriever ?? throw new ArgumentNullException(nameof(comicIssueByIdRetriever));
        }

        public Guid RetrieveFirstComicPageId(Guid currentComicIssueId)
        {
            ComicIssue comicIssue = _comicIssueByIdRetriever.GetComicIssue(currentComicIssueId);
            return comicIssue.Pages
                .OrderBy(page => page.PageNumber)
                .First()
                .PageId;
        }
    }
}
