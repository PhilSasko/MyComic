using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;

namespace MyComic.Domain.PageNavigation
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
            _comicIssueByIdRetriever = comicIssueByIdRetriever;
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
