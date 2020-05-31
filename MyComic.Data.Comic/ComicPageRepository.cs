using MyComic.Data.Comic.Dtos;
using MyComic.Data.Comic.Exceptions;
using MyComic.Files;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyComic.Data.Comic
{
    public interface IComicPageRepository
    {
        ComicPage GetComicPage(Func<ComicPage, bool> predicate);
    }

    public class ComicPageRepository : IComicPageRepository
    {
        private readonly IFileStringResolver _fileStringResolver;

        public ComicPageRepository(IFileStringResolver fileStringResolver)
        {
            _fileStringResolver = fileStringResolver ?? throw new ArgumentNullException(nameof(fileStringResolver));
        }

        public ComicPage GetComicPage(Func<ComicPage, bool> predicate)
        {
            string comicPagesJson = _fileStringResolver.ResolveStringFromFile("");
            try
            {
                IEnumerable<ComicPage> comicPages = JsonConvert.DeserializeObject<IEnumerable<ComicPage>>(comicPagesJson);
                IEnumerable<ComicPage> filteredComiicPages = comicPages.Where(cp => predicate(cp));
                // TODO: throw exception if Count of filteredComicPages is larger than 1
                return filteredComiicPages.FirstOrDefault();
            }
            catch (JsonReaderException)
            {
                throw new ComicDataException("Invalid data. Unable to resolve the comic page from the data");
            }
        }
    }
}
