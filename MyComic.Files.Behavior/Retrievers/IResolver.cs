using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Domain.Retrievers
{
    public interface IResolver<TSource, TTarget>
    {
        TTarget Resolve(TSource source);
    }

    public class ComicPageNameResolver : IResolver<int, string>
    {
        private readonly IFilePathRetriever _filePathRetriever;
        public ComicPageNameResolver(IFilePathRetriever filePathRetriever)
        {
            _filePathRetriever = filePathRetriever;
        }

        /**
         * TODO: the whole string should be dynamically generated. What if we want to change
         *       the way we organize pages? Maybe by issue then page. Maybe by arc, then issue,
         *       then page. This will probably change the file system. The logic to generate 
         *       the string shouldn't be here. It should be abstracted.
         *       
         *       It might be a good idea to have a project that deals with files. Or maybe have
         *       it be a part of a persistence project.
         * **/
        public string Resolve(int source)
        {
            string localPathPart = _filePathRetriever.Retrieve();
            return $@"{localPathPart}source\repos\MyComic\_images\{source}.jpg";
        }
    }
}
