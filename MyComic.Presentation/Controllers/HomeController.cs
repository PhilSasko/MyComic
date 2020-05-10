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

        public HomeController(ILogger<HomeController> logger, IComicPageBuilder comicPageBuilder)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _comicPageBuilder = comicPageBuilder ?? throw new ArgumentNullException(nameof(comicPageBuilder));
        }


        public IActionResult Index(int id = 0)
        {
            if (id == 0)
            {
                return GetDefaultPage();
            }
            else
            {
                ComicPage comicPage = _comicPageBuilder.BuildeComicPageFromPageNumber(id);
                ComicPageViewModel comicPageViewModel = new ComicPageViewModel()
                {
                    ComicPage = comicPage
                };
                return View(comicPageViewModel);
            }
        }

        public IActionResult NextPage(int pageNumber)
        {
            pageNumber++;
            return RedirectToAction("Index", new { Id = pageNumber });
        }

        // TODO: extract logic to a new class
        private IActionResult GetDefaultPage()
        {
            ComicPageViewModel defaultComicPageViewModel = new ComicPageViewModel()
            {
                ComicPage = new ComicPage() 
                { 
                    PageNumber = 0,
                    FileName = "cover.jpg"
                }
            };
            return View(defaultComicPageViewModel);
        }
    }
}
