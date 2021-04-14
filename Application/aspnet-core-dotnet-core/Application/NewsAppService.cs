using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Skyworkz.News.Domain;

namespace Skyworkz.News.Application
{
    public class NewsAppService : INewsAppService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;
        public NewsAppService(IMapper mapper, INewsRepository newsRepository)
        {
            _mapper = mapper;
            _newsRepository = newsRepository;
        }
        public Task Create(NewsViewModel news)
        {
            //TODO: create command and domain event handler to deal properly with this operation.
            var entity = _mapper.Map<NewsEntity>(news);

            return _newsRepository.Insert(entity);
        }

        public async Task<IEnumerable<NewsViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<NewsViewModel>>(await _newsRepository.GetAll());
        }

        public async Task<NewsViewModel> GetById(string id)
        {
            return _mapper.Map<NewsViewModel>(await _newsRepository.GetById(id));
        }
    }
}
