using BookHavenClassLibrary.Dtos.Book;

namespace BookHavenClassLibrary.Dtos.Sales
{
    public class SaleItemResponseDto
    {
        public int SaleItemId { get; set; }
        public int SaleId { get; set; }
        public int BookId { get; set; }
        public BookResponseDto? Book { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Discount { get; set; }
    }
}
