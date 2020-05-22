using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation
{
    public interface ILastComicPageNavigator
    {
        ComicPage LastComicPage(ComicPage currentComicPage);
    }
    public class LastComicPageNavigator : ILastComicPageNavigator
    {
        public ComicPage LastComicPage(ComicPage currentComicPage)
        {
            throw new NotImplementedException();
        }
    }
}
