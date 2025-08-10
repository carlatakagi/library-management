namespace LibraryMgmt.Models
{
    public class Book
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string Genre { get; set; }
        public DateTime PublishedDate { get; set; }
        public bool IsAvailable { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
