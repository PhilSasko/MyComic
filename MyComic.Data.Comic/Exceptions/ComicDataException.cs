using System;
using System.Collections.Generic;
using System.Text;

namespace MyComic.Data.Comic.Exceptions
{
    public class ComicDataException : Exception
    {
        public ComicDataException(string message) : base(message)
        {
            // Empty costructor
        }
    }
}
