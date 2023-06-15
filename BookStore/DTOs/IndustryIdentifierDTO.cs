using Newtonsoft.Json;

namespace BookStore.DTOs
{
    public class IndustryIdentifierDTO
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("identifier")]
        public string Identifier { get; set; }
    }
}
