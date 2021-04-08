﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Skyworkz.News.Domain
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<TEntity> GetById(Guid id);
        void Insert(TEntity entity);
    }
}
