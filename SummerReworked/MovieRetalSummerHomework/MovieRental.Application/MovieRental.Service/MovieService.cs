using MovieRental.DataBase;
using MovieRental.DataBase.EFImplementations;
using MovieRental.DataBase.Interfaces;
using MovieRental.Domain;
using MovieRental.Domain.Enums;
using MovieRental.Dtos.Dto;
using MovieRental.Service.Interfaces;

namespace MovieRental.Service
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Movie> _movieRepository;
        private readonly MovieRentalDbContext _dbContext;
        public MovieService(IRepository<Movie> movieRepository, IRepository<User> userRepository)
        {
            _movieRepository = movieRepository;
            _userRepository = userRepository;
        }

        public List<MovieDto> GetAllMovies()
        {
            return _movieRepository.GetAll().Select(x => new MovieDto
            {
                Id = x.Id,
                Title = x.Title,
                Genre = x.Genre,
                Language = x.Language,
                IsAvailable = x.IsAvailable,
                ReleaseDate = x.ReleaseDate,
                Length = x.Length,
                AgeRestriction = x.AgeRestriction,
                Quantity = x.Quantity
            }).ToList();
        }

        public MovieDto GetMovieById(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null) return null;
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Genre = movie.Genre,
                Language = movie.Language,
                IsAvailable = movie.IsAvailable,
                ReleaseDate = movie.ReleaseDate,
                Length = movie.Length,
                AgeRestriction = movie.AgeRestriction,
                Quantity = movie.Quantity
            };
        }


        public IEnumerable<Movie> IsOverCertainAge(int age)
        {
            var allMovies = _movieRepository.GetAll();

            var filteredMovies = allMovies.Where(m => m.AgeRestriction < 18);

            if (age < 18)
            {

                return filteredMovies;
            }

            return allMovies;
        }

        public void UpdateMovieQuantity(int movieId, int newQuantity)
        {
            var movie = _movieRepository.GetById(movieId);
            if (movie != null)
            {
                movie.Quantity = newQuantity;
                _movieRepository.Update(movie);
                _movieRepository.SaveChanges();
            }
        }
    }
}
