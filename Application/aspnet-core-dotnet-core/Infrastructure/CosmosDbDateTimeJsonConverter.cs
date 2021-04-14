using Newtonsoft.Json.Converters;

namespace Skyworkz.News.Infrastructure
{
    /// <summary>
    /// <see cref="JsonConverter" /> for Cosmos DB needed as long as the DateTime handling
    /// problem has not been fixed. 
    /// </summary>
    public class CosmosDbDateTimeJsonConverter : IsoDateTimeConverter
    {
        public CosmosDbDateTimeJsonConverter()
        {
            this.DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK";
        }

        #region Overrides of JsonConverter

        /// <inheritdoc />
        public override bool CanRead => false;

        #endregion
    }
}
