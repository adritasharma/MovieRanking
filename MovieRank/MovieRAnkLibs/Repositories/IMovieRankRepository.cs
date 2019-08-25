using MovieRAnkLibs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieRAnkLibs.Repositories
{
    public interface IMovieRankRepository
    {
        Task<IEnumerable<MovieDb>> GetAllItems();
        Task<MovieDb> GetMovie(int userId, string movieName);
        Task<IEnumerable<MovieDb>> GetUserRankedMoviesByMovieTitle(int userId, string movieName);
        Task AddMovie( MovieDb movie);
        Task UpdateMovie(MovieDb movie);
        Task<IEnumerable<MovieDb>> GetMoviesRanking(string movieName);
        Task DeleteMovieRanking(MovieDb movie);
    }
}
