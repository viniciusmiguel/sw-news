using System;
using Newtonsoft.Json;

namespace Skyworkz.News.Domain
{
    public class NewsEntity : Entity
    {
        public NewsEntity() { } //To EF
        public NewsEntity(string title, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Date = DateTime.Now;
        }
        
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime Date { get; protected set; }

    }
}
