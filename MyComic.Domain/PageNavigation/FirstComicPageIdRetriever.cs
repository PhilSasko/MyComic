using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;

namespace MyComic.Domain.PageNavigation
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
            _comicIssueByIdRetriever = comicIssueByIdRetriever;
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
