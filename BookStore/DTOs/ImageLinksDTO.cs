using Newtonsoft.Json;

namespace BookStore.DTOs
{
    public class ImageLinksDTO
    {
        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("smallThumbnail")]
        public string SmallThumbnail { get; set; }
    }
}
