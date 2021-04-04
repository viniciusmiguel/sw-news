using AutoMapper;
using Skyworkz.News.Domain;
using Skyworkz.News.ViewModels;

namespace Skyworkz.News.Mapping
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<NewsEntity, NewsViewModel>();
        }
    }
}
