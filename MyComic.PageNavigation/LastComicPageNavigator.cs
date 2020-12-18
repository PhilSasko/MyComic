using MyComic.Entities.Comic;
using MyComic.PageProviding;
using System;

namespace MyComic.PageNavigation
{
    public interface ILastComicPageNavigator
    {
        ComicPage GetLastComicPage(ComicIssue currentComicIssue);
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

        public ComicPage GetLastComicPage(ComicIssue currentComicIssue)
        {
            int lastComicPageNumber = _lastComicPageNumberResolver.ResolveLastComicPageNumberFromComicPage(currentComicIssue);

            return _comicPageBuilder.BuildeComicPageFromPageNumber(lastComicPageNumber);
        }
    }
}
