using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation
{
    public interface ILastComicPageNumberResolver
    {
        int ResolveLastComicPageNumberFromComicPage(ComicPage comicPage);
    }

    public class LastComicPageNumberResolver : ILastComicPageNumberResolver
    {
        public int ResolveLastComicPageNumberFromComicPage(ComicPage comicPage)
        {
            return comicPage.ComicIssue.NumberOfPages;
        }
    }
}
