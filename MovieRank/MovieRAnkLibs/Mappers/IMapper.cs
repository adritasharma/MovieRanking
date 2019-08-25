using MovieRankContracts;
using MovieRAnkLibs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRAnkLibs.Mappers
{
    public interface IMapper
    {
        IEnumerable<MovieRankResponse> ToMovieContract(IEnumerable<MovieDb> items);
        MovieRankResponse ToMovieContract(MovieDb movie);
        MovieDb ToMovieDbModel(int userId, MovieRankRequest movie);
        MovieDb ToMovieDbModel(int userId, MovieDb movie, MovieUpdateRequest movieUpdateRequest);
    }
}
