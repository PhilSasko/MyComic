using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Data.Comic.Dtos
{
    /// <summary>
    /// A dto, exposing a comic page from a data source
    /// </summary>
    public class ComicPage
    {
        public Guid ComicPageId { get; set; }
        public int IssueId { get; set; }
        public int PageNumber { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
    }
}
