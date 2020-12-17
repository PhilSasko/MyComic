using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation
{
    public interface ILastComicPageNumberResolver
    {
        int ResolveLastComicPageNumberFromComicPage(ComicIssue comicIssue);
    }

    public class LastComicPageNumberResolver : ILastComicPageNumberResolver
    {
        public int ResolveLastComicPageNumberFromComicPage(ComicIssue comicIssue) => comicIssue.NumberOfPages;
    }
}
