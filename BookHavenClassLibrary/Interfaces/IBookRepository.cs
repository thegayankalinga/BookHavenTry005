using BookHavenClassLibrary.Dtos.Book;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> AddBookAsync(BookRequestDto bookRequestDto);
        Task<List<BookResponseDto?>> GetAllBooksAsync();
        Task<BookResponseDto?> GetBookByIdAsync(int bookId);
        Task<bool> UpdateBookAsync(int bookId, BookRequestDto bookRequestDto);
        Task<bool> DeleteBookAsync(int bookId);
    }
}
