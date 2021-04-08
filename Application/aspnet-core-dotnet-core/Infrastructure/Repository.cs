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
        private readonly AppDbContext _db;

        protected Container Container;
        public Repository(AppDbContext db)
        {
            _db = db;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public TEntity GetById(Guid id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
            _db.SaveChanges();
        }
    }
}
