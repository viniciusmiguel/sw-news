using Skyworkz.News.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Skyworkz.News.Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public Repository()
        {
            //TODO: implement db context
        }
        public IQueryable<TEntity> GetAll()
        {
            //TODO: implement get operation
            return new EnumerableQuery<TEntity>(new List<TEntity>() {new NewsEntity("Title", "Description") as TEntity });
        }

        public TEntity GetById(Guid id)
        {
            //TODO: implement getbyid operation
            throw new NotImplementedException();
        }

        public void Insert(TEntity entity)
        {
            //TODO: implement insert operation.
            throw new NotImplementedException();
        }
    }
}
