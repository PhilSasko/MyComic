using System;
using Microsoft.AspNetCore.Mvc;
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

        public HomeController
            ( ILogger<HomeController> logger
            , IComicPageBuilder comicPageBuilder
            , IDefaultComicPageRetriever defaultComicPageRetriever)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _comicPageBuilder = comicPageBuilder ?? throw new ArgumentNullException(nameof(comicPageBuilder));
            _defaultComicPageRetriever = defaultComicPageRetriever ?? throw new ArgumentNullException(nameof(defaultComicPageRetriever));
        }

        public IActionResult Index(int id = 0)
        {
            ComicPage comicPage = 0 < id
                ? _comicPageBuilder.BuildeComicPageFromPageNumber(id)
                : _defaultComicPageRetriever.RetrieveDefaultComicPage();

            ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
            {
                ComicPage = comicPage
            };

            return View(comicPageViewModel);
    }

        public IActionResult NextPage(int pageNumber)
        {
            pageNumber++;
            return RedirectToAction("Index", new { Id = pageNumber });
        }

        public IActionResult PreviousPage(int pageNumber)
        {
            pageNumber--;
            return RedirectToAction("Index", new { Id = pageNumber });
        }
    }
}
