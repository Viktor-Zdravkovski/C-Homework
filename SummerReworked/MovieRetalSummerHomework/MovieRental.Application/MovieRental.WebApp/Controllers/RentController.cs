using Microsoft.AspNetCore.Mvc;
using MovieRental.Domain;
using MovieRental.Service.Interfaces;

namespace MovieRental.WebApp.Controllers
{
	public class RentController : Controller
	{
        private readonly IFilterService _filterService;
        private readonly IMovieService _movieService;
        private readonly IUserService _userService;
        private readonly IRentalService _rentalService;
        public RentController(IFilterService filterService, IRentalService rentalService, IMovieService movieService, IUserService userService)
        {
            _filterService = filterService;
            _rentalService = rentalService;
            _movieService = movieService;
            _userService = userService;
        }



        [HttpGet("rentMovie")]
        public IActionResult RentMovie()
        {
            return View();
        }

        [HttpPost("rentMovie")]
        public IActionResult Rent(int movieId)
        {
            string cardNumber = HttpContext.Session.GetString("CurrentCardNumber");

            if (string.IsNullOrWhiteSpace(cardNumber))
            {
                return RedirectToAction("Login", "Account");
            }

            var user = _userService.GetCurrentUser(cardNumber);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var movie = _movieService.GetMovieById(movieId);
            if (movie == null)
            {
                return NotFound("Movie not found.");
            }

            //if (movie.Quantity <= 0)
            //{
            //    return BadRequest("Movie not available.");
            //}

            var rental = new Rental
            {
                UserId = user.Id,
                MovieId = movieId,
                RentedOn = DateTime.UtcNow,
                ReturnedOn = null
            };

            _rentalService.CreateRental(rental);
            _movieService.UpdateMovieQuantity(movieId, movie.Quantity - 1); // Ensure you have this method in your service

            return RedirectToAction("GetMovieDetails", new { id = movieId });
        }
    }

}

