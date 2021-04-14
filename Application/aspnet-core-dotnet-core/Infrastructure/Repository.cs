using Skyworkz.News.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;


namespace Skyworkz.News.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity :  class, IEntity, new()
    {
        private readonly CosmosDB _db;

        protected Container Container;
        public Repository(CosmosDB db)
        {
            _db = db;
            var obj = new TEntity();
            Container = _db.DB.CreateContainerIfNotExistsAsync(obj.GetType().Name, "/id", 400).Result.Container;
            Console.WriteLine("Selected Container: " + Container.Id);
        }

        public async Task Insert(TEntity entity)
        {
            try
            {
                var response = await Container
                    .ReadItemAsync<TEntity>(entity.id, new PartitionKey(entity.id));
                Console.WriteLine("Item in database with id: {0} already exists\n",
                    response.Resource.id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                await Container.CreateItemAsync(entity, new PartitionKey(entity.id));
            }
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                var sqlQueryText = "SELECT * FROM c";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                FeedIterator<TEntity> queryResultSetIterator = Container.GetItemQueryIterator<TEntity>(queryDefinition);
                var l = new List<TEntity>();
                while (queryResultSetIterator.HasMoreResults)
                {
                    var currentResultSet = await queryResultSetIterator.ReadNextAsync();
                    foreach (var entity in currentResultSet)
                    {
                        l.Add(entity);
                    }
                }

                return l;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return default;
        }

        public async Task<TEntity> GetById(string id)
        {
            try
            {
                return await Container.ReadItemAsync<TEntity>(id, new PartitionKey(id.ToString()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return default;
        }
    }
}
