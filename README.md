# MovieRanking

A Basic ASP.NET Core Application to perform CRUD Operation with  DynamoDB on AWS.

# AWS DynamoDB

Amazon DynamoDB is a fast and flexible NoSQL database service. It is a fully managed database that supports both document and key-value data models.

### Create a DynamoDB Table


**AWS Console Steps for DynamoDB**

- Go to Service -> DynamoDB
- Create table


### Connect .NET Core Application with DynamoDB

To connect with DynamoDB, AWS Nuget Package **AWSSDK.DynamoDBv2** has been used. 

```
using (var client = new AmazonDynamoDBClient())
{
   using (var context = new DynamoDBContext(client))
   {
      await context.SaveAsync(dbModel);
   }
}
```

In order to use DataModel with DynamoDB, some attributes from Amazon.DynamoDBv2.DataModel like [DynamoDBTable], [DynamoDBProperty] has been added to it.

```
    [DynamoDBTable("MovieRank")]
    public class MovieDb
    {
        [DynamoDBHashKey]
        public int UserId { get; set; }
        [DynamoDBGlobalSecondaryIndexHashKey]
        public string MovieName { get; set; }
        public string Description { get; set; }
        public List<string> Actors { get; set; }
        public int Ranking { get; set; }
        public string RankedDateTime { get; set; }

    }
```

### Scan and Query

To retrieve data from DynamoDBm we can use 2 options **Scan** and **Query** function.

- **Scan** : Reads all item in table but comes at a cost. All items are read before the filter is applied.
```
     public async Task<IEnumerable<MovieDb>> GetAllItems()
     {
        return await _dbContext.ScanAsync<MovieDb>(new List<ScanCondition>()).GetRemainingAsync();
     }

```

- **Query** : Reads items more efficiently, but we must add the Partition key and optionally the sort key to the correct attributes.
```
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
```
