using MyComic.Entities.Comic;

namespace MyComic.PageNavigation
{
    public interface IComicIssueResolver
    {
        ComicIssue ResolveComicIssue(int comicIssueNumber);
    }

    public class ComicIssueResolver : IComicIssueResolver
    {
        public ComicIssue ResolveComicIssue(int comicIssueNumber)
        {
            // TODO: obviously a temporary workaround. Fix once we can have multiple issues.
            return new ComicIssue() { NumberOfPages = 32, IssueNumber = 1 };
        }
    }
}
