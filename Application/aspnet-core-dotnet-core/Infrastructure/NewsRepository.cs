using Skyworkz.News.Domain;

namespace Skyworkz.News.Infrastructure
{
    public class NewsRepository : Repository<NewsEntity>, INewsRepository
    {
        public NewsRepository(CosmosDB db) : base(db)
        {
        }
    }
}
