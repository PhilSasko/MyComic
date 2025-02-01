using Microsoft.AspNetCore.Mvc;
using MyComic.Domain.DataAccess;
using MyComic.Domain.Entities.Comic;
using MyComic.Domain.PageNavigation;
using MyComic.Domain.PageProviding;
using MyComic.Presentation.Models;

namespace MyComic.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDefaultComicPageRetriever _defaultComicPageRetriever;
        private readonly IComicIssueResolver _comicIssueResolver;
        private readonly IComicPageFromIdRetriever _comicPageFromIdRetriever;
        private readonly INextComicPageIdRetriever _nextComicPageIdRetriever;
        private readonly IPreviousComicPageIdRetriever _previousComicPageIdRetriever;
        private readonly ILastComicPageIdRetriever _lastComicPageIdRetriever;
        private readonly IFirstComicPageIdRetriever _firstComicPageIdRetriever;

        public HomeController
            (ILogger<HomeController> logger
            , IDefaultComicPageRetriever defaultComicPageRetriever
            , IComicIssueResolver comicIssueResolver
            , IComicPageFromIdRetriever comicPageFromIdRetriever
            , INextComicPageIdRetriever nextComicPageIdRetriever
            , IPreviousComicPageIdRetriever previousComicPageIdRetriever
            , ILastComicPageIdRetriever lastComicPageIdRetriever
            , IFirstComicPageIdRetriever firstComicPageIdRetriever)
        {
            _logger = logger;
            _defaultComicPageRetriever = defaultComicPageRetriever;
            _comicIssueResolver = comicIssueResolver;
            _comicPageFromIdRetriever = comicPageFromIdRetriever;
            _nextComicPageIdRetriever = nextComicPageIdRetriever;
            _previousComicPageIdRetriever = previousComicPageIdRetriever;
            _lastComicPageIdRetriever = lastComicPageIdRetriever;
            _firstComicPageIdRetriever = firstComicPageIdRetriever;
        }

        public IActionResult Index(Guid? pageId)
        {
            ComicPage comicPage = pageId is null
                ? _defaultComicPageRetriever.RetrieveDefaultComicPage()
                : _comicPageFromIdRetriever.RetrieveComicPageFromId(pageId.Value);

            ComicIssue comicIssue = _comicIssueResolver.ResolveComicIssue(comicPage.IssueId);

            ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
            {
                ComicPage = comicPage,
                ComicIssue = comicIssue
            };

            return View(comicPageViewModel);
        }

        public IActionResult FirstPage(Guid issueId)
        {
            Guid firstComicPageId = _firstComicPageIdRetriever.RetrieveFirstComicPageId(currentComicIssueId: issueId);
            return RedirectToAction("Index", new { PageId = firstComicPageId });
        }

        public IActionResult PreviousPage(Guid pageId)
        {
            Guid previousComicPageId = _previousComicPageIdRetriever.RetrievePreviousComicPageId(currentPageId: pageId);
            return RedirectToAction("Index", new { PageId = previousComicPageId });
        }

        public IActionResult NextPage(Guid pageId)
        {
            Guid nextComicPageId = _nextComicPageIdRetriever.RetrieveNextComicPageId(currentPageId: pageId);
            return RedirectToAction("Index", new { PageId = nextComicPageId });
        }

        public IActionResult LastPage(Guid issueId)
        {
            Guid lastComicPageId = _lastComicPageIdRetriever.RetrieveLastComicPageId(currentComicIssueId: issueId);
            return RedirectToAction("Index", new { PageId = lastComicPageId });
        }
    }
}