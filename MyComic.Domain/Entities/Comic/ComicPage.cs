namespace MyComic.Domain.Entities.Comic
{
    public class ComicPage
    {
        public Guid PageId { get; set; }
        public int IssueId { get; set; }
        public int PageNumber { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ComicIssue ComicIssue { get; set; } = new ComicIssue();
    }
}
