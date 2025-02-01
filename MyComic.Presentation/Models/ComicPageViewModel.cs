using MyComic.Domain.Entities.Comic;

namespace MyComic.Presentation.Models
{
    public class ComicPageViewModel
    {
        public ComicPage ComicPage { get; set; } = new ComicPage();
        public ComicIssue ComicIssue { get; set; } = new ComicIssue();
    }
}
