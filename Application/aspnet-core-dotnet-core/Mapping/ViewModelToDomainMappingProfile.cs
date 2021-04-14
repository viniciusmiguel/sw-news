using System;
using System.Globalization;
using AutoMapper;
using Skyworkz.News.Domain;
using Skyworkz.News.ViewModels;

namespace Skyworkz.News.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<NewsViewModel, NewsEntity>().ConstructUsing(e => new NewsEntity(e.Title, e.Description));
        }
    }
}
