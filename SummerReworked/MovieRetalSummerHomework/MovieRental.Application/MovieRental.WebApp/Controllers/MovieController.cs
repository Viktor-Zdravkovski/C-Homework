using Microsoft.AspNetCore.Mvc;
using MovieRental.DataBase;
using MovieRental.Domain;
using MovieRental.Dtos.Dto;
using MovieRental.Service.Interfaces;

namespace MovieRental.WebApp.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieRentalDbContext _context;
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("allMovies")]
        public IActionResult GetAll()
        {
            var movies = _movieService.GetAllMovies();
            return View(movies);
        }

        [HttpGet("details")]
        public IActionResult GetMovieDetails(int id)
        {
            var moviebyId = _movieService.GetMovieById(id);
            return View(moviebyId);
        }
    }
}
