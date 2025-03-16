using BookHavenClassLibrary.Enumz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Dtos.Book
{
    public class BookResponseDto
    {
        public int BookId { get; set; }
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required BookGenres BookGenre { get; set; }
        public string? Isbn { get; set; }
        public required decimal SellingPrice { get; set; }
        public required int StockQuantity { get; set; }
    }
}
