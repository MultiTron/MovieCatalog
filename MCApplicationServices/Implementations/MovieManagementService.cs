using MCApplicationServices.Interfaces;
using MCApplicationServices.Messaging.Requsets;
using MCApplicationServices.Messaging.Responses;
using MCData.Context;
using Microsoft.EntityFrameworkCore;

namespace MCApplicationServices.Implementations
{
    public class MovieManagementService : IMovieManagementService
    {
        private readonly MovieCatalogDbContext _context;
        public MovieManagementService(MovieCatalogDbContext context)
        {
            _context = context;
        }
        public async Task<GetMoviesResponse> GetMovies()
        {
            GetMoviesResponse response = new() { Movies = new() };
            var movies = await _context.Movies.Include("Genre").Include("Rating").ToListAsync();

            foreach (var movie in movies)
            {
                response.Movies.Add(new() { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Country = movie.Country, Studio = movie.Studio, Genre = movie.Genre.Name, Rating = movie.Rating.Score });
            }
            return response;
        }
        public async Task<GetMoviesResponse> GetMovies(PagingRequest request)
        {
            GetMoviesResponse response = new() { Movies = new() };
            var movies = await _context.Movies.Include("Genre").Include("Rating").ToListAsync();

            foreach (var movie in movies.Skip((request.CurrentPage - 1) * request.ElementsPerPage).Take(request.ElementsPerPage))
            {
                response.Movies.Add(new() { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Country = movie.Country, Studio = movie.Studio, Genre = movie.Genre.Name, Rating = movie.Rating.Score });
            }
            return response;
        }
        public async Task<GetMoviesResponse> GetMoviesByTitle(string title)
        {
            GetMoviesResponse response = new() { Movies = new() };
            var movies = await _context.Movies.Include("Genre").Include("Rating").Where(x => x.Title.Contains(title)).ToListAsync();
            foreach (var movie in movies)
            {
                response.Movies.Add(new() { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Country = movie.Country, Studio = movie.Studio, Genre = movie.Genre.Name, Rating = movie.Rating.Score });
            }
            return response;
        }
        public async Task<GetMoviesResponse> GetMoviesByGenre(string genre)
        {
            GetMoviesResponse response = new() { Movies = new() };
            var movies = await _context.Movies.Include("Genre").Include("Rating").Where(x => x.Genre.Name.Equals(genre)).ToListAsync();
            foreach (var movie in movies)
            {
                response.Movies.Add(new() { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Country = movie.Country, Studio = movie.Studio, Genre = movie.Genre.Name, Rating = movie.Rating.Score });
            }
            return response;
        }
        public async Task<GetMoviesResponse> GetMoviesByRating(string rating)
        {
            GetMoviesResponse response = new() { Movies = new() };
            var movies = await _context.Movies.Include("Genre").Include("Rating").Where(x => x.Rating.Score.Equals(rating)).ToListAsync();
            foreach (var movie in movies)
            {
                response.Movies.Add(new() { Title = movie.Title, ReleaseDate = movie.ReleaseDate, Country = movie.Country, Studio = movie.Studio, Genre = movie.Genre.Name, Rating = movie.Rating.Score });
            }
            return response;
        }

        public async Task<CreateMovieResponse> CreateMovie(CreateMovieRequest request)
        {
            await _context.Movies.AddAsync(new()
            {
                Title = request.Movie.Title,
                GenreId = request.Movie.GenreId,
                RatingId = request.Movie.RatingId,
                Country = request.Movie.Country,
                Studio = request.Movie.Studio,
                CreatedBy = "Me",
                CreatedOn = DateTime.UtcNow,
                IsActive = true,
            });
            await _context.SaveChangesAsync();
            return new();
        }
    }
}
