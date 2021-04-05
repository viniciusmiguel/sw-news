using System;
using Newtonsoft.Json;

namespace Skyworkz.News.Domain
{
    public abstract class Entity
    {
        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; protected set; }
    }
}
