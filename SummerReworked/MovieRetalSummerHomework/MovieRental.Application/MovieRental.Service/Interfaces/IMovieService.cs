using MovieRental.Domain;
using MovieRental.Dtos.Dto;

namespace MovieRental.Service.Interfaces
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies();

        MovieDto GetMovieById(int id);

        IEnumerable<Movie> IsOverCertainAge(int age);

        void UpdateMovieQuantity(int movieId, int newQuantity);
    }
}
