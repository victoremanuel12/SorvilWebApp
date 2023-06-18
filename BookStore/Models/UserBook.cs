namespace BookStore.Models
{
    public enum BookStatus
    {
        Desisti,
        Lendo,
        Concluído
    }
    public class UserBook
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string Image { get; set; }
        public int PageCount { get; set; }
        public string IndustryIdentifier { get; set; }
        public DateTime PublishedDate { get; set; }
        public BookStatus Status { get; set; }
        public virtual int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
