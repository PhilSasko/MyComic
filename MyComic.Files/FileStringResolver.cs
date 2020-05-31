using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Files
{
    public interface IFileStringResolver
    {
        string ResolveStringFromFile(string fileName);
    }

    public class FileStringResolver : IFileStringResolver
    {
        public string ResolveStringFromFile(string fileName)
        {
            // TODO: get contents from separate file
            return 
                "[" +
                "   {" +
                "       \"ComicPageId\" : \"11111111-1111-1111-1111-111111111111\"," +
                "       \"IssueId\" : 1," +
                "       \"PageNumber\" : 1," +
                "       \"FileName\" : \"01.jpg\"," +
                "       \"Description\" : \"The first page\"" +
                "   }," +
                "   {" +
                "       \"ComicPageId\" : \"22222222-2222-2222-2222-222222222222\"," +
                "       \"IssueId\" : 1," +
                "       \"PageNumber\" : 2," +
                "       \"FileName\" : \"02.jpg\"," +
                "       \"Description\" : \"The second page\"" +
                "   }" +
                "]";
        }
    }
}
