using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Entities.Comic
{
    public interface IComicEnumerable : IEnumerable<ComicPage> { }

    public class ComicEnumerable : IComicEnumerable
    {
        private IEnumerable<ComicPage> _comicPages;
        public IEnumerator<ComicPage> GetEnumerator() => _comicPages.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    public class ComicIssue : ComicEnumerable
    {
    }
}
