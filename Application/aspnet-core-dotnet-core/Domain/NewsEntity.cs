using System;
using Newtonsoft.Json;

namespace Skyworkz.News.Domain
{
    public class NewsEntity : Entity
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
        
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime Date { get; private set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
