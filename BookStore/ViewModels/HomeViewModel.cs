using BookStore.Models;

namespace BookStore.ViewModels
{
    public class HomeViewModel
    {
        public List<UserBook> LivrosNaoLidos { get; set; }
        public List<UserBook> LivrosLerei { get; set; }
        public List<UserBook> LivrosLendo { get; set; }
        public List<UserBook> LivrosConcluidos { get;set; }
    }
}
