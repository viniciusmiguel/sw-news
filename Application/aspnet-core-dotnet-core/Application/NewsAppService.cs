using Skyworkz.News.ViewModels;
using System;
using System.Collections.Generic;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        public void Create(NewsViewModel news)
        {
            //TODO: create command and domain event handler to deal properly with this operation.
            var entity = _mapper.Map<Domain.NewsEntity>(news);

            _newsRepository.Insert(entity);
        }

        public IEnumerable<NewsViewModel> GetAll()
        {
            return _newsRepository.GetAll().ProjectTo<NewsViewModel>(_mapper.ConfigurationProvider);
        }

        public NewsViewModel GetById(Guid id)
        {
            return _mapper.Map<NewsViewModel>(_newsRepository.GetById(id));
        }
    }
}
