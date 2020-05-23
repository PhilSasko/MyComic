using MyComic.Entities.Comic;
using System;

namespace MyComic.PageNavigation
{
    public interface ILastComicPageNavigator
    {
        ComicPage GetLastComicPage(ComicPage currentComicPage);
    }
    public class LastComicPageNavigator : ILastComicPageNavigator
    {
        private readonly IComicPageBuilder _comicPageBuilder;
        private readonly ILastComicPageNumberResolver _lastComicPageNumberResolver;

        public LastComicPageNavigator(IComicPageBuilder comicPageBuilder, ILastComicPageNumberResolver lastComicPageNumberResolver)
        {
            _comicPageBuilder = comicPageBuilder 
                ?? throw new ArgumentNullException(nameof(comicPageBuilder));
            _lastComicPageNumberResolver = lastComicPageNumberResolver 
                ?? throw new ArgumentNullException(nameof(lastComicPageNumberResolver));
        }

        public ComicPage GetLastComicPage(ComicPage currentComicPage)
        {
            int lastComicPageNumber = _lastComicPageNumberResolver.ResolveLastComicPageNumberFromComicPage(currentComicPage);

            return _comicPageBuilder.BuildeComicPageFromPageNumber(lastComicPageNumber);
        }
    }
}
