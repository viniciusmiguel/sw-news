using System;
using System.Linq;

namespace Skyworkz.News.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
        void Insert(TEntity entity);
    }
}
