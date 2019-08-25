using MovieRankContracts;
using MovieRAnkLibs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRAnkLibs.Mappers
{
    public class Mapper : IMapper
    {
        public IEnumerable<MovieRankResponse> ToMovieContract(IEnumerable<MovieDb> items)
        {
            return items.Select(ToMovieContract);
        }

        public MovieRankResponse ToMovieContract(MovieDb movie)
        {
            return new MovieRankResponse
            {
                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movie.Ranking,
                TimeRanked = movie.RankedDateTime
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieRankRequest movie)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movie.Ranking,
                RankedDateTime =DateTime.UtcNow.ToString()
            };
        }

        public MovieDb ToMovieDbModel(int userId, MovieDb movie, MovieUpdateRequest movieUpdateRequest)
        {
            return new MovieDb
            {
                UserId = userId,
                MovieName = movie.MovieName,
                Description = movie.Description,
                Actors = movie.Actors,
                Ranking = movieUpdateRequest.Ranking,
                RankedDateTime = DateTime.UtcNow.ToString()
            };
        }
    }
}
