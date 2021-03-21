using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Entities.Comic
{
    public class ComicIssue
    {
        public Guid IssueId { get; set; }
        public int IssueNumber { get; set; }
        public int NumberOfPages { get; set; }
        public IEnumerable<ComicPage> Pages { get; set; }
    }
}
