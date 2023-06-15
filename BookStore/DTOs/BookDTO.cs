using Newtonsoft.Json;

namespace BookStore.DTOs
{
    public class BookDTO
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("volumeInfo")]
        public VolumeInfoDTO VolumeInfo { get; set; }
    }
}
