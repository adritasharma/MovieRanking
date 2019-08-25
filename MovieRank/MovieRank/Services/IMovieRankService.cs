using MovieRankContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRank.Services
{
    public interface IMovieRankService
    {
        Task<IEnumerable<MovieRankResponse>> GetAllItems();
        Task<MovieRankResponse> GetMovie(int userId, string movieName);
        Task<IEnumerable<MovieRankResponse>> GetUserRankedMoviesByMovieTitle(int userId, string movieName);
        Task AddMovie(int userId, MovieRankRequest movie);
        Task UpdateMovie(int userId, MovieUpdateRequest movie);
        Task<MovieOverallRankResponse> GetMoviesRanking(string movieName);
        Task DeleteMovieRanking(int userId, string movieName);
    }
}
