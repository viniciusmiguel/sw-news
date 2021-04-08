using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Skyworkz.News.Application
{
    public interface INewsAppService
    {
        Task<IEnumerable<NewsViewModel>> GetAll();
        Task<NewsViewModel> GetById(Guid id);
        Task Create(NewsViewModel news);
    }
}
