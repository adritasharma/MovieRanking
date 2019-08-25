using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using MovieRAnkLibs.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieRAnkLibs.Repositories
{
    public class MovieRankRepository : IMovieRankRepository
    {
        private readonly DynamoDBContext _dbContext;

        public MovieRankRepository(IAmazonDynamoDB dynamoDBClient)
        {
            _dbContext = new DynamoDBContext(dynamoDBClient);
        }

        public async Task AddMovie(MovieDb movie)
        {
            await _dbContext.SaveAsync(movie);
        }

        public async Task<IEnumerable<MovieDb>> GetAllItems()
        {
            return await _dbContext.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
        }

        public async Task<MovieDb> GetMovie(int userId, string movieName)
        {
            return await _dbContext.LoadAsync<MovieDb>(userId, movieName);
        }

        public async Task<IEnumerable<MovieDb>> GetUserRankedMoviesByMovieTitle(int userId, string movieName)
        {
            var config = new DynamoDBOperationConfig
            {
                QueryFilter = new List<ScanCondition>
                {
                    new ScanCondition("MovieName", ScanOperator.BeginsWith, movieName)
                }
            };
            return await _dbContext.QueryAsync<MovieDb>(userId, config).GetRemainingAsync();

        }

        public async Task UpdateMovie(MovieDb movie)
        {
            await _dbContext.SaveAsync(movie);
        }


        public async Task<IEnumerable<MovieDb>> GetMoviesRanking(string movieName)
        {
            var config = new DynamoDBOperationConfig
            {
                IndexName = "MovieName-index"
            };
            return await _dbContext.QueryAsync<MovieDb>(movieName, config).GetRemainingAsync();
        }

        public async Task DeleteMovieRanking(MovieDb movie)
        {
            await _dbContext.DeleteAsync(movie);
        }
    }
}
