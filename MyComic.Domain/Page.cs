using System;

namespace MyComic.Domain
{
    public class Page
    {
        public int IssueId { get; set; }
        public int PageNumber { get; set; }
        public string Description { get; set; }
    }
}
