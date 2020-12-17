using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation
{
    public class ComicPageNavigationContext
    {
        public ComicPage CurrentComicPage { get; set; }
        public ComicIssue ComicIssue { get; set; }
    }
}
