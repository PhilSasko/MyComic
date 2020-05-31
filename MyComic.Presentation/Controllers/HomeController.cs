using System;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using MyComic.Entities.Comic;
using MyComic.PageNavigation;
using MyComic.Presentation.Models;

namespace MyComic.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IComicPageBuilder _comicPageBuilder;
        private readonly IDefaultComicPageRetriever _defaultComicPageRetriever;
        private readonly INextComicPageNavigator _nextComicPageNavigator;
        private readonly IPreviousComicPageNavigator _previousComicPageNavigator;
        private readonly ILastComicPageNavigator _lastComicPageNavigator;
        private readonly IComicIssueResolver _comicIssueResolver;

        const int ComonNumberOfPages = 32;   // TODO: temporary workaround. Remove when restructure of page navigation.

        public HomeController
            ( ILogger<HomeController> logger
            , IComicPageBuilder comicPageBuilder
            , IDefaultComicPageRetriever defaultComicPageRetriever
            , INextComicPageNavigator nextComicPageNavigator
            , IPreviousComicPageNavigator previousComicPageNavigator
            , ILastComicPageNavigator lastComicPageNavigator
            , IComicIssueResolver comicIssueResolver)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            _comicPageBuilder = comicPageBuilder
                ?? throw new ArgumentNullException(nameof(comicPageBuilder));
            _defaultComicPageRetriever = defaultComicPageRetriever
                ?? throw new ArgumentNullException(nameof(defaultComicPageRetriever));
            _nextComicPageNavigator = nextComicPageNavigator
                ?? throw new ArgumentNullException(nameof(nextComicPageNavigator));
            _previousComicPageNavigator = previousComicPageNavigator
                ?? throw new ArgumentNullException(nameof(previousComicPageNavigator));
            _lastComicPageNavigator = lastComicPageNavigator
                ?? throw new ArgumentNullException(nameof(lastComicPageNavigator));
            _comicIssueResolver = comicIssueResolver
                ?? throw new ArgumentNullException(nameof(comicIssueResolver));
        }

        public IActionResult Index(int id = 0, int issueNumber = 1)
        {
            ComicPage comicPage = 0 < id
                ? _comicPageBuilder.BuildeComicPageFromPageNumber(id)
                : _defaultComicPageRetriever.RetrieveDefaultComicPage();

            ComicIssue comicIssue = _comicIssueResolver.ResolveComicIssue(issueNumber);
            comicPage.ComicIssue = comicIssue;

            ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
            {
                ComicPage = comicPage
            };

            return View(comicPageViewModel);
        }

        public IActionResult FirstPage(int pageNumber, int issueNumber)
        {
            // TODO: Implement the first page button functionality.
            throw new NotImplementedException();
        }

        public IActionResult PreviousPage(int pageNumber, int issueNumber)
        {
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);
            ComicPage previousComicPage = _previousComicPageNavigator.GetPreviousComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = previousComicPage.PageNumber, IssueNumber = issueNumber });
        }

        public IActionResult NextPage(int pageNumber, int issueNumber)
        {
            // TODO: GetNextComicPage should not care about the comic page without taking into consideration the comic issue.
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);
            ComicPage nextComicPage = _nextComicPageNavigator.GetNextComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = nextComicPage.PageNumber, IssueNumber = issueNumber });
        }

        public IActionResult LastPage(int pageNumber, int issueNumber)
        {
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);

            ComicIssue comicIssue = _comicIssueResolver.ResolveComicIssue(issueNumber);
            // TODO: this is a workaround until I restructure things
            currentComicPage.ComicIssue = comicIssue;

            ComicPage lastComicPage = _lastComicPageNavigator.GetLastComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = lastComicPage.PageNumber, IssueNumber = issueNumber });
        }
    }
}
