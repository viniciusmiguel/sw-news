using System;


namespace Skyworkz.News.Domain
{
    public class NewsEntity
    {
        protected NewsEntity()
        {
            
        }
        public NewsEntity(string title, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Date = DateTime.Now;
        }
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        
    }
}
