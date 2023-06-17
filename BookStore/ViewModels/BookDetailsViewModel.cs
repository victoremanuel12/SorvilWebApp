using BookStore.DTOs;
using Newtonsoft.Json;

namespace BookStore.ViewModels
{
    public class BookDetailsViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public List<string> Authors { get; set; }

        public string Description { get; set; }

        public int PageCount { get; set; }

        public List<IndustryIdentifierDTO> IndustryIdentifiers { get; set; }

        public ImageLinksDTO ImageLinks { get; set; }

        public string PublishedDate { get; set; }
    }
}
