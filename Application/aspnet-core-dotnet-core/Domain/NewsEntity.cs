using System;
using System.Globalization;
using Newtonsoft.Json;

namespace Skyworkz.News.Domain
{
    public class NewsEntity : IEntity
    {

        public NewsEntity()
        {
        } //To EF
        public NewsEntity(string title, string description)
        {
            Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
            When = DateTime.Today;
        }
        
        public string Title { get;  set; }
        public string Description { get;  set; }
        public DateTime When { get;  set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string id
        {
            get => "NewsEntity|" + Id;
            set
            {
                Id = value.Split("|")[1];
            }
        }
        public string Id { get; set; }
    }
}
