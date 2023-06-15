using Newtonsoft.Json;

namespace BookStore.DTOs
{
    public class VolumeInfoDTO
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("authors")]
        public List<string> Authors { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("pageCount")]
        public int PageCount { get; set; }

        [JsonProperty("industryIdentifiers")]
        public List<IndustryIdentifierDTO> IndustryIdentifiers { get; set; }

        [JsonProperty("imageLinks")]
        public ImageLinksDTO ImageLinks { get; set; }

        [JsonProperty("publishedDate")]
        public string PublishedDate { get; set; }

    }
}
