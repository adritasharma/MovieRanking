using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRank.Services;
using MovieRankContracts;

namespace MovieRank.Controllers
{
    [Route("movies")]
    public class MovieController : Controller
    {
        private readonly IMovieRankService _movieRankService;

        public MovieController(IMovieRankService movieRankService)
        {
            _movieRankService = movieRankService;
        }


        //https://localhost:44375/movies
        public async Task<IEnumerable<MovieRankResponse>> GetAllItems()
        {
            var result = await _movieRankService.GetAllItems();
            return result;
        }


        //https://localhost:44375/movies/2/Dhadkan
        [HttpGet]
        [Route("{userId}/{movieName}")]
        public async Task<MovieRankResponse> GetUserId(int userId, string movieName)
        {
            var result = await _movieRankService.GetMovie(userId, movieName);
            return result;
        }

        //https://localhost:44375/movies/user/2/rankedMovies/Dha
        [HttpGet]
        [Route("user/{userId}/rankedMovies/{movieName}")]
        public async Task<IEnumerable<MovieRankResponse>> GetUserRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var result = await _movieRankService.GetUserRankedMoviesByMovieTitle(userId, movieName);
            return result;
        }

        //https://localhost:44375/movies/2

        //{
        // "MovieName" :"Khubsoorat",
        // "Description" :"Comedy",
        // "Actors" :["Sonam","Fawad"],
        // "Ranking" :9
        //}
        [HttpPost]
        [Route("{userId}")]
        public async Task<IActionResult> AddMovie(int userId, [FromBody] MovieRankRequest movie)
        {
            await _movieRankService.AddMovie(userId, movie);
            return Ok();
        }


    //https://localhost:44375/movies/2

    //{
	   // "MovieName" :"Khubsoorat",
	   // "Ranking" :6
    //}

        [HttpPatch]
        [Route("{userId}")]
        public async Task<IActionResult> UpdateMovie(int userId, [FromBody] MovieUpdateRequest movie)
        {
            await _movieRankService.UpdateMovie(userId, movie);
            return Ok();
        }

        //https://localhost:44375/movies/Khubsoorat/ranking
        [HttpGet]
        [Route("{movieName}/ranking")]
        public async Task<MovieOverallRankResponse> GetMoviesRanking(string movieName)
        {
            var result = await _movieRankService.GetMoviesRanking( movieName);
            return result;
        }
       // https://localhost:44375/movies/2/Dhadkan
        [HttpDelete]
        [Route("{userId}/{movieName}")]
        public async Task<IActionResult> DeleteMovieRanking(int userId, string movieName)
        {
            await _movieRankService.DeleteMovieRanking(userId, movieName);
            return Ok();
        }
    }
}