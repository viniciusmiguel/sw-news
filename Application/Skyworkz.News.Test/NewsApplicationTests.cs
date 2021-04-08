using AutoMapper;
using Moq;
using NUnit.Framework;
using Skyworkz.News.Application;
using Skyworkz.News.Domain;
using Skyworkz.News.Mapping;
using Skyworkz.News.ViewModels;

namespace Skyworkz.News.Test
{
    public class NewsAppTests
    {
        private IMapper mapper;
        private Mock<INewsRepository> newsRepositoryMock;
        [SetUp]
        public void Setup()
        {
            var dmToVm = new DomainToViewModelMappingProfile();
            var vmToDm = new ViewModelToDomainMappingProfile();
            var mapperConf = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(dmToVm);
                cfg.AddProfile(vmToDm);
            });

            mapper = new Mapper(mapperConf);

            newsRepositoryMock = new Mock<INewsRepository>();
            newsRepositoryMock.SetupAllProperties();
        }

        [Test]
        public void ShouldCreateNewEntityInRepository()
        {
            var newsAppSvc = new NewsAppService(mapper, newsRepositoryMock.Object);
            var vm = new NewsViewModel()
            {
                Title = "Title Test",
                Description = "Description Test"
            };
            newsAppSvc.Create(vm);
            newsRepositoryMock.Verify(o => o.Insert(It.IsAny<NewsEntity>()), Times.Once);
            Assert.Pass();
        }
    }
}