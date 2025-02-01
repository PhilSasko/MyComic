using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageProviding.DataRetrieval;

namespace MyComic.Domain.DataAccess
{
    public class ComicIssuePageRetriever : IComicIssuePageRetriever
    {
        public IEnumerable<ComicPage> RetrieveComicPagesForIssue(int comicIssueNumber)
        {
            return new List<ComicPage>
            {
                new ComicPage()
                {
                    PageId = new Guid("d57756a7-5ae9-4b96-8a83-9220c9eb173d"),
                    IssueId = comicIssueNumber,
                    PageNumber = 0,
                    FileName = "cover.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("66c4eff1-d7d6-44f4-b162-c71784aa162f"),
                    IssueId = comicIssueNumber,
                    PageNumber = 1,
                    FileName = "01.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("07ddadef-831a-4c42-8caf-0ea140aeff12"),
                    IssueId = comicIssueNumber,
                    PageNumber = 2,
                    FileName = "02.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("2542fae4-9795-4215-9459-c6928ac3380e"),
                    IssueId = comicIssueNumber,
                    PageNumber = 3,
                    FileName = "03.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("b2b0c8c0-aae5-4150-b68a-1ea8e029e2bc"),
                    IssueId = comicIssueNumber,
                    PageNumber = 4,
                    FileName = "04.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("2ec76b80-d127-4ff5-8087-d79d1f69be94"),
                    IssueId = comicIssueNumber,
                    PageNumber = 5,
                    FileName = "05.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("18441cd9-a1c4-4fcd-9239-c501f5e4538d"),
                    IssueId = comicIssueNumber,
                    PageNumber = 6,
                    FileName = "06.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("b4df6425-0ec5-47f1-b5c8-ad5feea3c95d"),
                    IssueId = comicIssueNumber,
                    PageNumber = 7,
                    FileName = "07.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("9d64a7b0-446d-46e4-afe3-a64f3ecb2fc5"),
                    IssueId = comicIssueNumber,
                    PageNumber = 8,
                    FileName = "08.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("0cc47212-fd95-4d84-83b1-e52a4ff3462e"),
                    IssueId = comicIssueNumber,
                    PageNumber = 9,
                    FileName = "09.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("c43df32a-73cd-4b11-a630-6bae6d75f9f5"),
                    IssueId = comicIssueNumber,
                    PageNumber = 10,
                    FileName = "10.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("a5bf60c1-89b8-4aed-ae85-109af48e48d9"),
                    IssueId = comicIssueNumber,
                    PageNumber = 11,
                    FileName = "11.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("5d1a237c-6320-4326-bc73-dbbccc0a1c50"),
                    IssueId = comicIssueNumber,
                    PageNumber = 12,
                    FileName = "12.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("188d62d4-2d5c-4428-9a49-77bc93c2f06f"),
                    IssueId = comicIssueNumber,
                    PageNumber = 13,
                    FileName = "13.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("b79de05b-bfdb-45f7-ba70-010445866ddd"),
                    IssueId = comicIssueNumber,
                    PageNumber = 14,
                    FileName = "14.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("44759d4d-f32d-4f44-b8e9-9e9717beb02b"),
                    IssueId = comicIssueNumber,
                    PageNumber = 15,
                    FileName = "15.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("546c5bf8-a3e6-4f58-a99d-300f4b68c41c"),
                    IssueId = comicIssueNumber,
                    PageNumber = 16,
                    FileName = "16.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("af0ca339-c305-4ef4-a928-4effbbabc692"),
                    IssueId = comicIssueNumber,
                    PageNumber = 17,
                    FileName = "17.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("65839bb8-b5b3-42a6-b193-6960faf25b82"),
                    IssueId = comicIssueNumber,
                    PageNumber = 18,
                    FileName = "18.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("63085d7c-9769-494e-bf5d-0bf940a3427a"),
                    IssueId = comicIssueNumber,
                    PageNumber = 19,
                    FileName = "19.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("593fe6cf-4b8e-4eb3-96d5-c26131306cef"),
                    IssueId = comicIssueNumber,
                    PageNumber = 20,
                    FileName = "20.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("3f803cc4-a5db-442b-8fd3-75f6f3641f08"),
                    IssueId = comicIssueNumber,
                    PageNumber = 21,
                    FileName = "21.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("e7f0a7e0-4c2a-473a-a707-56992e0f6bc0"),
                    IssueId = comicIssueNumber,
                    PageNumber = 22,
                    FileName = "22.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("6bf31daa-1ac6-4e18-a24c-94c2ca3b2786"),
                    IssueId = comicIssueNumber,
                    PageNumber = 23,
                    FileName = "23.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("ec742e74-61d7-41db-abe2-b5b8a9c784e3"),
                    IssueId = comicIssueNumber,
                    PageNumber = 24,
                    FileName = "24.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("0a283a9c-88cf-4d42-bbbc-9089610c2fb8"),
                    IssueId = comicIssueNumber,
                    PageNumber = 25,
                    FileName = "25.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("448e31f2-e36f-41ae-baca-54a8307af482"),
                    IssueId = comicIssueNumber,
                    PageNumber = 26,
                    FileName = "26.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("5915bd0f-0fee-4459-b3fa-a1f2a3102a42"),
                    IssueId = comicIssueNumber,
                    PageNumber = 27,
                    FileName = "27.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("aa99ef35-4923-4c48-aeb5-52da930c5f75"),
                    IssueId = comicIssueNumber,
                    PageNumber = 28,
                    FileName = "28.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("9f793976-f3a8-469d-8a96-1dc174644618"),
                    IssueId = comicIssueNumber,
                    PageNumber = 29,
                    FileName = "29.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("c12e9676-08bd-46d8-b1f6-9c345f70c6e3"),
                    IssueId = comicIssueNumber,
                    PageNumber = 30,
                    FileName = "30.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("c7f6fe71-f559-4a2f-b543-dcc46a6042b7"),
                    IssueId = comicIssueNumber,
                    PageNumber = 31,
                    FileName = "31.jpg"
                },
                new ComicPage()
                {
                    PageId = new Guid("8c69a7a8-df2c-456e-af00-d428d6febdb3"),
                    IssueId = comicIssueNumber,
                    PageNumber = 32,
                    FileName = "32.jpg"
                },
            };
        }
    }
}
