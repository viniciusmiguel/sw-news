using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;


namespace Skyworkz.News.Application
{
    public interface INewsAppService
    {
        IEnumerable<NewsViewModel> GetAll();
        NewsViewModel GetById(Guid id);
        void Create(NewsViewModel news);
    }
}
