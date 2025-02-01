using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;

namespace MyComic.Domain.DataAccess
{
    public class ComicIssueByIdRetriever : IComicIssueByIdRetriever
    {
        private readonly IComicIssuePageRetriever _comicIssuePageRetriever;

        public ComicIssueByIdRetriever(IComicIssuePageRetriever comicIssuePageRetriever)
        {
            _comicIssuePageRetriever = comicIssuePageRetriever;
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
