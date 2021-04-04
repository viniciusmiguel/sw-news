using AutoMapper;
using Skyworkz.News.Domain;
using Skyworkz.News.ViewModels;

namespace Skyworkz.News.Mapping
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<NewsViewModel, NewsEntity>();
        }
    }
}
