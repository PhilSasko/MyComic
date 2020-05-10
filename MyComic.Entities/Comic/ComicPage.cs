using System;

namespace MyComic.Entities.Comic
{
    public class ComicPage
    {
        public int IssueId { get; set; }
        public int PageNumber { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}
