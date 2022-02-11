using Moq;
using MyComic.Entities.Comic;
using MyComic.PageProviding.DataRetrieval;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace MyComic.PageNavigation.Tests
{
    [TestFixture]
    internal class FirstComicPageIdRetrieverTests
    {
        [Test]
        public void RetrieveFirstComicPageId_WhenThreePages_ReturnsFirstPage()
        {
            Mock<IComicIssueByIdRetriever> mockComicIssueByIdRetriever = new Mock<IComicIssueByIdRetriever>();
            mockComicIssueByIdRetriever.Setup(cibir => cibir.GetComicIssue(It.IsAny<Guid>())).Returns(new ComicIssue()
            {
                IssueId = new Guid("075b6e68-9d2f-476f-9e92-1e8e4b870f8e"),
                IssueNumber = 1,
                NumberOfPages = 3,
                Pages = new List<ComicPage>
                {
                    new ComicPage()
                    {
                        PageId = new Guid("c0150c76-eab2-4efe-be90-8bd129eed9b0"),
                        PageNumber = 1
                    },
                    new ComicPage()
                    {
                        PageId = new Guid("30bcc30a-73eb-40dc-981d-30de31983a16"),
                        PageNumber = 2
                    },
                    new ComicPage()
                    {
                        PageId = new Guid("926edcd6-6d48-43ac-a0f1-93cb235d0a8d"),
                        PageNumber = 3
                    },
                }
            });
            IFirstComicPageIdRetriever lastComicPageIdRetriever = new FirstComicPageIdRetriever(mockComicIssueByIdRetriever.Object);
            Guid currentComicIssueId = new Guid("075b6e68-9d2f-476f-9e92-1e8e4b870f8e");

            Guid firstComicPageId = lastComicPageIdRetriever.RetrieveFirstComicPageId(currentComicIssueId);

            Assert.That(firstComicPageId, Is.EqualTo(new Guid("c0150c76-eab2-4efe-be90-8bd129eed9b0")));
        }
    }
}
