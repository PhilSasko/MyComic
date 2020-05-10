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
            if (0 < id)
            {
                ComicPage comicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(id);
                ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
                {
                    ComicPage = comicPage
                };
                return View(comicPageViewModel);
            }
            else
            {
                ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
                {
                    ComicPage = _defaultComicPageRetriever.RetrieveDefaultComicPage()
                };
                return View(comicPageViewModel);
            }
        }

        public IActionResult NextPage(int pageNumber)
        {
            pageNumber++;
            return RedirectToAction("Index", new { Id = pageNumber });
        }
    }
}
