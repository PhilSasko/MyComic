using System;

namespace MyComic.Domain.Comic
{
    public class ComicPage
    {
        public int IssueId { get; set; }
        public int PageNumber { get; set; }
        public string Description { get; set; }
    }
}
