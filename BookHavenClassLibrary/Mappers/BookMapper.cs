using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Mappers
{
    public class BookMapper
    {
        public static BookResponseDto? MapToBookResponseDto(Book book)
        {
            if (book == null) throw new ArgumentNullException(nameof(book));

            return new BookResponseDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Author = book.Author,
                BookGenre = book.BookGenre,
                Isbn = book.Isbn,
                SellingPrice = book.SellingPrice,
                StockQuantity = book.StockQuantity,
                QuanitySold = book.QuantitySold
            };
        }

        public static Book MapToBook(BookRequestDto bookRequest)
        {
            return new Book
            {
                Title = bookRequest.Title,
                Author = bookRequest.Author,
                BookGenre = bookRequest.BookGenre,
                Isbn = bookRequest.Isbn,
                SellingPrice = bookRequest.SellingPrice,
                StockQuantity = bookRequest.StockQuantity
            };
        }

    }
}
