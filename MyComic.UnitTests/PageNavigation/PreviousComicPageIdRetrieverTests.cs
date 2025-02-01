using Moq;
using MyComic.Domain.PageProviding.DataRetrieval;
using MyComic.Domain.Entities.Comic;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using MyComic.Domain.PageNavigation;

namespace MyComic.UnitTests.PageNavigation
{
    [TestFixture]
    public class PreviousComicPageIdRetrieverTests
    {
        [Test]
        public void RetrievePreviousComicPageId_WhenTwoPagesAndOnSecondPage_ReturnsFirstPage()
        {
            Guid firstPageId = new Guid("66c4eff1-d7d6-44f4-b162-c71784aa162f");
            Guid secondPageId = new Guid("07ddadef-831a-4c42-8caf-0ea140aeff12");
            IEnumerable<ComicPage> comicPages = new List<ComicPage>
            {
                new ComicPage()
                {
                    PageId = firstPageId,
                    IssueId = 1,
                    PageNumber = 1,
                    FileName = "01.jpg"
                },
                new ComicPage()
                {
                    PageId = secondPageId,
                    IssueId = 1,
                    PageNumber = 2,
                    FileName = "02.jpg"
                }
            };

            Mock<IComicIssuePageRetriever> mockComicIssuePageRetriever = new Mock<IComicIssuePageRetriever>();
            mockComicIssuePageRetriever.Setup(cipr => cipr.RetrieveComicPagesForIssue(It.IsAny<int>())).Returns(comicPages);

            PreviousComicPageIdRetriever previousComicPageIdRetriever = new PreviousComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid previousComicPageId = previousComicPageIdRetriever.RetrievePreviousComicPageId(secondPageId);

            Assert.That(previousComicPageId, Is.EqualTo(firstPageId));
        }

        [Test]
        public void RetrievePreviousComicPageId_WhenThreePagesAndOnSecondPage_ReturnsFirstPagesId()
        {
            Guid firstPageId = new Guid("66c4eff1-d7d6-44f4-b162-c71784aa162f");
            Guid secondPageId = new Guid("07ddadef-831a-4c42-8caf-0ea140aeff12");
            Guid thirdPageId = new Guid("2542fae4-9795-4215-9459-c6928ac3380e");
            IEnumerable<ComicPage> comicPages = new List<ComicPage>
            {
                new ComicPage()
                {
                    PageId = firstPageId,
                    IssueId = 1,
                    PageNumber = 1,
                    FileName = "01.jpg"
                },
                new ComicPage()
                {
                    PageId = secondPageId,
                    IssueId = 1,
                    PageNumber = 2,
                    FileName = "02.jpg"
                },
                new ComicPage()
                {
                    PageId = thirdPageId,
                    IssueId = 1,
                    PageNumber = 3,
                    FileName = "03.jpg"
                }
            };

            Mock<IComicIssuePageRetriever> mockComicIssuePageRetriever = new Mock<IComicIssuePageRetriever>();
            mockComicIssuePageRetriever.Setup(cipr => cipr.RetrieveComicPagesForIssue(It.IsAny<int>())).Returns(comicPages);

            PreviousComicPageIdRetriever previousComicPageIdRetriever = new PreviousComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid previousComicPageId = previousComicPageIdRetriever.RetrievePreviousComicPageId(secondPageId);

            Assert.That(previousComicPageId.ToString(), Is.EqualTo(firstPageId.ToString()));
        }

        [Test]
        public void RetrievePreviousComicPageId_WhenTwoPagesAndOnFirstPage_ReturnsCurrentPage()
        {
            Guid firstPageId = new Guid("66c4eff1-d7d6-44f4-b162-c71784aa162f");
            Guid secondPageId = new Guid("07ddadef-831a-4c42-8caf-0ea140aeff12");
            IEnumerable<ComicPage> comicPages = new List<ComicPage>
            {
                new ComicPage()
                {
                    PageId = firstPageId,
                    IssueId = 1,
                    PageNumber = 1,
                    FileName = "01.jpg"
                },
                new ComicPage()
                {
                    PageId = secondPageId,
                    IssueId = 1,
                    PageNumber = 2,
                    FileName = "02.jpg"
                }
            };

            Mock<IComicIssuePageRetriever> mockComicIssuePageRetriever = new Mock<IComicIssuePageRetriever>();
            mockComicIssuePageRetriever.Setup(cipr => cipr.RetrieveComicPagesForIssue(It.IsAny<int>())).Returns(comicPages);

            PreviousComicPageIdRetriever previousComicPageIdRetriever = new PreviousComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid previousComicPageId = previousComicPageIdRetriever.RetrievePreviousComicPageId(firstPageId);

            Assert.That(previousComicPageId.ToString(), Is.EqualTo(firstPageId.ToString()));
        }

        [Test]
        public void RetrievePreviousComicPageId_PageCannotBeFound_ThrowsArgumentException()
        {
            Guid firstPageId = new Guid("66c4eff1-d7d6-44f4-b162-c71784aa162f");
            Guid secondPageId = new Guid("07ddadef-831a-4c42-8caf-0ea140aeff12");
            IEnumerable<ComicPage> comicPages = new List<ComicPage>
            {
                new ComicPage()
                {
                    PageId = firstPageId,
                    IssueId = 1,
                    PageNumber = 1,
                    FileName = "01.jpg"
                },
                new ComicPage()
                {
                    PageId = secondPageId,
                    IssueId = 1,
                    PageNumber = 2,
                    FileName = "02.jpg"
                }
            };

            Mock<IComicIssuePageRetriever> mockComicIssuePageRetriever = new Mock<IComicIssuePageRetriever>();
            mockComicIssuePageRetriever.Setup(cipr => cipr.RetrieveComicPagesForIssue(It.IsAny<int>())).Returns(comicPages);

            PreviousComicPageIdRetriever nextComicPageIdRetriever = new PreviousComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid notIncludedPageId = new Guid("2542fae4-9795-4215-9459-c6928ac3380e");

            Assert.Throws<ArgumentException>(() => nextComicPageIdRetriever.RetrievePreviousComicPageId(notIncludedPageId));
        }
    }
}
