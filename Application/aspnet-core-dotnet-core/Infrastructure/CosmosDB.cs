using System;
using Microsoft.Azure.Cosmos;

namespace Skyworkz.News.Infrastructure
{
    public class CosmosDB : IDisposable
    {
        private readonly CosmosClient _cosmosClient;
        public readonly Database DB;
        public CosmosDB()
        {
            var connectionString = Environment.GetEnvironmentVariable("cosmos-connection-string");
            Console.WriteLine("The connection string is: " + connectionString);
            _cosmosClient = new CosmosClient(connectionString);
            DB = _cosmosClient.GetDatabase("skyworkz-news-cosmos-db-sql");
            Console.WriteLine("Database Selected: " + DB.Id);

        }

        public void Dispose()
        {
            _cosmosClient?.Dispose();
        }
    }
}