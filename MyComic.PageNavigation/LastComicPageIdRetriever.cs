using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System;
using System.Linq;

namespace MyComic.PageNavigation
{
    public interface ILastComicPageIdRetriever
    {
        Guid RetrieveLastComicPageId(Guid currentComicIssueId);
    }
    public class LastComicPageIdRetriever : ILastComicPageIdRetriever
    {
        private readonly IComicIssueByIdRetriever _comicIssueByIdRetriever;

        public LastComicPageIdRetriever(IComicIssueByIdRetriever comicIssueByIdRetriever)
        {
            _comicIssueByIdRetriever = comicIssueByIdRetriever ?? throw new ArgumentNullException(nameof(comicIssueByIdRetriever));
        }

        public Guid RetrieveLastComicPageId(Guid currentComicIssueId)
        {
            ComicIssue comicIssue = _comicIssueByIdRetriever.GetComicIssue(currentComicIssueId);
            return comicIssue.Pages
                .OrderByDescending(page => page.PageNumber)
                .First()
                .PageId;
        }
    }
}
