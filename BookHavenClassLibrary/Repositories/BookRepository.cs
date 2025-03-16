using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext context)
        {
            _appDbContext = context;
        }

        public async Task<bool> AddBookAsync(BookRequestDto bookRequestDto)
        {
            var book = BookMapper.MapToBook(bookRequestDto);
            try
            {
                await _appDbContext.Books.AddAsync(book);
                await _appDbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public async Task<List<BookResponseDto?>> GetAllBooksAsync()
        {
            var books = await _appDbContext.Books.ToListAsync();
            return books.Select(BookMapper.MapToBookResponseDto).ToList();
        }

        public async Task<BookResponseDto?> GetBookByIdAsync(int bookId)
        {
            var book = await _appDbContext.Books.FindAsync(bookId);

            if (book == null)
                return null;

            return BookMapper.MapToBookResponseDto(book);
        }

        public async Task<bool> UpdateBookAsync(int bookId, BookRequestDto bookRequestDto)
        {
            var book = await _appDbContext.Books.FindAsync(bookId);

            if (book == null)
                return false;

            book.Title = bookRequestDto.Title;
            book.Author = bookRequestDto.Author;
            book.BookGenre = bookRequestDto.BookGenre;
            book.Isbn = bookRequestDto.Isbn;
            book.SellingPrice = bookRequestDto.SellingPrice;
            book.StockQuantity = bookRequestDto.StockQuantity;

            _appDbContext.Books.Update(book);
            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            var book = await _appDbContext.Books.FindAsync(bookId);

            if (book == null)
                return false;

            _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
    }
}
