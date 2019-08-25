using MovieRankContracts;
using MovieRAnkLibs.Mappers;
using MovieRAnkLibs.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRank.Services
{
    public class MovieRankService : IMovieRankService
    {
        private readonly IMovieRankRepository _movieRankRepository;
        private readonly IMapper _map;

        public MovieRankService(IMovieRankRepository movieRankRepository, IMapper map)
        {
            _movieRankRepository = movieRankRepository;
            _map = map;
        }

        public async Task AddMovie(int userId, MovieRankRequest movie)
        {
            var movieDb = _map.ToMovieDbModel(userId, movie);
            await _movieRankRepository.AddMovie(movieDb);
        }

        public async Task DeleteMovieRanking(int userId, string movieName)
        {
            var movie = await _movieRankRepository.GetMovie(userId, movieName);
            await _movieRankRepository.DeleteMovieRanking(movie);
        }

        public async Task<IEnumerable<MovieRankResponse>> GetAllItems()
        {
            var response = await _movieRankRepository.GetAllItems();
            return _map.ToMovieContract(response);
        }

        public async Task<MovieRankResponse> GetMovie(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetMovie(userId, movieName);
            return _map.ToMovieContract(response);
        }

        public async Task<MovieOverallRankResponse> GetMoviesRanking(string movieName)
        {
            var response = await _movieRankRepository.GetMoviesRanking(movieName);
            var overAllRanking = Math.Round(response.Select(x => x.Ranking).Average());

            return new MovieOverallRankResponse
            {
                MovieName = movieName,
                OverAllRank = overAllRanking
            };
        }

        public async Task<IEnumerable<MovieRankResponse>> GetUserRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var response = await _movieRankRepository.GetUserRankedMoviesByMovieTitle(userId, movieName);
            return _map.ToMovieContract(response);
        }

        public async Task UpdateMovie(int userId, MovieUpdateRequest request)
        {

            var response = await _movieRankRepository.GetMovie(userId, request.MovieName);
            var movieDb = _map.ToMovieDbModel(userId, response ,request);
            await _movieRankRepository.UpdateMovie(movieDb);
        }
    }
}
