﻿using MCInfrastructure.Messaging.Requsets;
using MCInfrastructure.Messaging.Requsets.Movies;
using MCInfrastructure.Messaging.Responses.Movies;

namespace MCApplicationServices.Interfaces
{
    public interface IMovieManagementService
    {
        Task<GetMoviesResponse> GetActiveMovies(IsActiveRequest request);
        Task<GetMoviesResponse> GetMovies(PagingRequest request);
        Task<GetMoviesResponse> GetMoviesByTitle(string title);
        Task<GetMoviesResponse> GetMoviesByGenre(string genre);
        Task<GetMoviesResponse> GetMoviesByRating(string rating);
        Task<CreateMovieResponse> CreateMovie(CreateMovieRequest request);
        Task<DeleteMovieResponse> DeleteMovie(DeleteMovieRequest request);
    }
}
