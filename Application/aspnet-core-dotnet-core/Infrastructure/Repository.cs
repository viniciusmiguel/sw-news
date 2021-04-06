using Microsoft.Azure.Cosmos;
using Skyworkz.News.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace Skyworkz.News.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        private readonly CosmosDB _db;

        protected Container Container;
        public Repository(CosmosDB db)
        {
            _db = db;
            var obj = new TEntity();
            Container = _db.DB.CreateContainerIfNotExistsAsync(obj.GetType().Name, "/Id", 400).Result.Container;
            Console.WriteLine("Selected Container: " + Container.Id);
        }

        private T Read<T>(Guid id)
        {
            try
            {
                return Container.ReadItemAsync<T>(id.ToString(), new PartitionKey(id.ToString())).Result.Resource;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return default;
        }

        private IEnumerable<T> ReadAll<T>()
        {
            try
            {
                var sqlQueryText = "SELECT * FROM c";
                QueryDefinition queryDefinition = new QueryDefinition(sqlQueryText);
                FeedIterator<T> queryResultSetIterator = Container.GetItemQueryIterator<T>(queryDefinition);
                var l = new List<T>();
                while (queryResultSetIterator.HasMoreResults)
                {
                    var currentResultSet = queryResultSetIterator.ReadNextAsync().Result;
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
        public IQueryable<TEntity> GetAll()
        {
            return ReadAll<TEntity>().AsQueryable();
        }

        public TEntity GetById(Guid id)
        {
            return Read<TEntity>(id);
        }

        public void Insert(TEntity entity)
        {
            try
            {
                ItemResponse<TEntity> wakefieldFamilyResponse = Container
                    .ReadItemAsync<TEntity>(entity.Id.ToString(), new PartitionKey(entity.Id.ToString())).Result;
                Console.WriteLine("Item in database with id: {0} already exists\n",
                    wakefieldFamilyResponse.Resource.Id);
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                Container.CreateItemAsync(entity, new PartitionKey(entity.Id.ToString()));
            }
        }
    }
}
