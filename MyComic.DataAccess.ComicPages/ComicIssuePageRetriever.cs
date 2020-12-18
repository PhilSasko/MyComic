using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using System.Collections.Generic;

namespace MyComic.DataAccess.ComicPages
{
    public class ComicIssuePageRetriever : IComicIssuePageRetriever
    {
        public IEnumerable<ComicPage> RetrieveComicPagesForIssue(int comicIssueNumber)
        {
            return new List<ComicPage>
            {
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 1,
                    FileName = "01.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 2,
                    FileName = "02.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 3,
                    FileName = "03.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 4,
                    FileName = "04.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 5,
                    FileName = "05.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 6,
                    FileName = "06.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 7,
                    FileName = "07.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 8,
                    FileName = "08.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 9,
                    FileName = "09.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 10,
                    FileName = "10.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 11,
                    FileName = "11.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 12,
                    FileName = "12.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 13,
                    FileName = "13.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 14,
                    FileName = "14.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 15,
                    FileName = "15.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 16,
                    FileName = "16.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 17,
                    FileName = "17.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 18,
                    FileName = "18.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 19,
                    FileName = "19.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 20,
                    FileName = "20.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 21,
                    FileName = "21.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 22,
                    FileName = "22.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 23,
                    FileName = "23.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 24,
                    FileName = "24.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 25,
                    FileName = "25.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 26,
                    FileName = "26.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 27,
                    FileName = "27.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 28,
                    FileName = "28.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 29,
                    FileName = "29.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 30,
                    FileName = "30.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 31,
                    FileName = "31.jpg"
                },
                new ComicPage()
                {
                    IssueId = comicIssueNumber,
                    PageNumber = 32,
                    FileName = "32.jpg"
                },
            };
        }
    }
}
