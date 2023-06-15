using Newtonsoft.Json;

namespace BookStore.DTOs
{
    public class GoogleBookResponseDTO
    {
        [JsonProperty("items")]
        public List<BookDTO> Items { get; set; }
    }
}
