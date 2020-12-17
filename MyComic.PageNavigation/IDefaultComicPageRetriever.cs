using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.PageNavigation
{
    public interface IDefaultComicPageRetriever
    {
        ComicPage RetrieveDefaultComicPage();
    }

    public class DefaultComicPageRetriever : IDefaultComicPageRetriever
    {
        public ComicPage RetrieveDefaultComicPage()
        {
            return new ComicPage()
            {
                PageNumber = 0,
                FileName = "cover.jpg"
            };
        }
    }
}
