using BookStore.DTOs;

namespace BookStore.ViewModels
{
    public class BookViewModel
    {
        public string ResultadoDaBusca { get; set; }
        public List<BookDTO> Items { get; set; }

    }
}
