using Newtonsoft.Json;
using System.Collections.Generic;

namespace EntitiesLayer.Entities
{
    public class TriviaApiResponse
    {
        [JsonProperty("results")]
        public List<TriviaQuestion> Results { get; set; }
    }
}