using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Skyworkz.News.Application
{
    public interface INewsAppService
    {
        Task<IEnumerable<NewsViewModel>> GetAll();
        Task<NewsViewModel> GetById(string id);
        Task Create(NewsViewModel news);
    }
}
