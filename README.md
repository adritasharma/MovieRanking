# MovieRanking

A Basic ASP.NET Core Application to perform CRUD Operation with  DynamoDB on AWS.

# AWS DynamoDB

Amazon DynamoDB is a fast and flexible NoSQL database service. It is a fully managed database that supports both document and key-value data models.

### Create a DynamoDB Table


**AWS Console Steps for DynamoDB**

- Go to Service -> DynamoDB
- Create table


### Connect .NET Core Application with DynamoDB

To connect with DynamoDB, AWS Nuget Package **AWSSDK.DynamoDBv2** has been used. In order to use DataModel with DynamoDB, some attributes from Amazon.DynamoDBv2.DataModel like [DynamoDBTable], [DynamoDBProperty] has been added to it.

```
using (var client = new AmazonDynamoDBClient())
{
   using (var context = new DynamoDBContext(client))
   {
      await context.SaveAsync(dbModel);
   }
}
```
