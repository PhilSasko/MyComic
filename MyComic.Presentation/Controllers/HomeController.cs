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
        private readonly IPreviousComicPageNavigator _previousComicPageNavigator;
        private readonly ILastComicPageNavigator _lastComicPageNavigator;
        private readonly IComicIssueResolver _comicIssueResolver;

        public HomeController
            ( ILogger<HomeController> logger
            , IComicPageBuilder comicPageBuilder
            , IDefaultComicPageRetriever defaultComicPageRetriever
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

            ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
            {
                ComicPage = comicPage,
                ComicIssue = comicIssue
            };

            return View(comicPageViewModel);
        }

        public IActionResult FirstPage(int issueNumber)
        {
            throw new NotImplementedException("Implement the first page button functionality.");
        }

        public IActionResult PreviousPage(int pageNumber, int issueNumber)
        {
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);
            ComicPage previousComicPage = _previousComicPageNavigator.GetPreviousComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = previousComicPage.PageNumber, IssueNumber = issueNumber });
        }

        public IActionResult NextPage(int id, int issueNumber)
        {
            ComicIssue comicIssue = _comicIssueResolver.ResolveComicIssue(issueNumber);
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(id);

            // TODO: update this to calculate the next page instead of just sending back the current page.
            return RedirectToAction("Index", new { id = currentComicPage.PageNumber, IssueNumber = issueNumber });
        }

        public IActionResult LastPage(int issueNumber)
        {
            ComicIssue comicIssue = _comicIssueResolver.ResolveComicIssue(issueNumber);

            ComicPage lastComicPage = _lastComicPageNavigator.GetLastComicPage(comicIssue);

            return RedirectToAction("Index", new { Id = lastComicPage.PageNumber, IssueNumber = issueNumber });
        }
    }
}
