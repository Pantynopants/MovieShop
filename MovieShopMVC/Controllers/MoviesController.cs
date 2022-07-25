using ApplicationCore.ServiceContracts;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using MovieShopMVC.Models;
using System.Diagnostics;

namespace MovieShopMVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            // go to movie service -> movie repository and get movie details from Movies Table
            var movieDetails = _movieService.GetMovieDetails(id);
            return View(movieDetails);
        }
    }
}
