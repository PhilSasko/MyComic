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
    public class NextComicPageIdRetrieverTests
    {
        [Test]
        public void RetrieveNextComicPageId_WhenTwoPagesAndOnFirstPage_ReturnsSecondPagesId()
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

            NextComicPageIdRetriever nextComicPageIdRetriever = new NextComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid nextComicPageId = nextComicPageIdRetriever.RetrieveNextComicPageId(firstPageId);

            Assert.That(nextComicPageId.ToString(), Is.EqualTo(secondPageId.ToString()));
        }

        [Test]
        public void RetrieveNextComicPageId_WhenThreePagesAndOnSecondPage_ReturnsThirdPagesId()
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

            NextComicPageIdRetriever nextComicPageIdRetriever = new NextComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid nextComicPageId = nextComicPageIdRetriever.RetrieveNextComicPageId(secondPageId);

            Assert.That(nextComicPageId.ToString(), Is.EqualTo(thirdPageId.ToString()));
        }

        [Test]
        public void RetrieveNextComicPageId_WhenTwoPagesAndOnLastPage_ReturnsCurrentPage()
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

            NextComicPageIdRetriever nextComicPageIdRetriever = new NextComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid nextComicPageId = nextComicPageIdRetriever.RetrieveNextComicPageId(secondPageId);

            Assert.That(nextComicPageId.ToString(), Is.EqualTo(secondPageId.ToString()));
        }

        [Test]
        public void RetrieveNextComicPageId_PageCannotBeFound_ThrowsArgumentException()
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

            NextComicPageIdRetriever nextComicPageIdRetriever = new NextComicPageIdRetriever(mockComicIssuePageRetriever.Object);

            Guid notIncludedPageId = new Guid("2542fae4-9795-4215-9459-c6928ac3380e");

            Assert.Throws<ArgumentException>(() => nextComicPageIdRetriever.RetrieveNextComicPageId(notIncludedPageId));
        }
    }
}
