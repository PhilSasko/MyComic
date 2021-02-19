using MyComic.Entities.Comic;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.DataAccess.ComicPages
{
    public interface IComicPageFromIdRetriever
    {
        ComicPage RetrieveComicPageFromId(Guid pageId);
    }

    public class ComicPageFromIdRetriever : IComicPageFromIdRetriever
    {
        public ComicPage RetrieveComicPageFromId(Guid pageId)
        {
            throw new NotImplementedException();
        }
    }
}
