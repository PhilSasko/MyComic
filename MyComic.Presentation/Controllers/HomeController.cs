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

        const int ComonNumberOfPages = 32;   // TODO: temporary workaround. Remove when restructure of page navigation.

        public HomeController
            ( ILogger<HomeController> logger
            , IComicPageBuilder comicPageBuilder
            , IDefaultComicPageRetriever defaultComicPageRetriever
            , INextComicPageNavigator nextComicPageNavigator
            , IPreviousComicPageNavigator previousComicPageNavigator
            , ILastComicPageNavigator lastComicPageNavigator)
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
        }

        public IActionResult Index(int id = 0)
        {
            ComicPage comicPage = 0 < id
                ? _comicPageBuilder.BuildeComicPageFromPageNumber(id)
                : _defaultComicPageRetriever.RetrieveDefaultComicPage();

            // TODO: this is a workaround until I restructure things
            ComicIssue comicIssue = new ComicIssue() { NumberOfPages = ComonNumberOfPages };
            comicPage.ComicIssue = comicIssue;

            ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
            {
                ComicPage = comicPage
            };

            return View(comicPageViewModel);
        }

        public IActionResult LastPage(int pageNumber)
        {
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);

            // TODO: this is a workaround until I restructure things
            ComicIssue comicIssue = new ComicIssue() { NumberOfPages = ComonNumberOfPages };
            currentComicPage.ComicIssue = comicIssue;

            ComicPage lastComicPage = _lastComicPageNavigator.GetLastComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = lastComicPage.PageNumber });
        }

        public IActionResult PreviousPage(int pageNumber)
        {
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);
            ComicPage previousComicPage = _previousComicPageNavigator.GetPreviousComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = previousComicPage.PageNumber });
        }

        public IActionResult NextPage(int pageNumber)
        {
            ComicPage currentComicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(pageNumber);
            ComicPage nextComicPage = _nextComicPageNavigator.GetNextComicPage(currentComicPage);

            return RedirectToAction("Index", new { Id = nextComicPage.PageNumber });
        }
    }
}
