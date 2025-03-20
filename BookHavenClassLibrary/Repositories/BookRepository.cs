using BookHavenClassLibrary.Connections;
using BookHavenClassLibrary.Dtos.Book;
using BookHavenClassLibrary.Interfaces;
using BookHavenClassLibrary.Mappers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookHavenClassLibrary.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public BookRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<bool> BookExist(int bookId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            return await dbContext.Books.AnyAsync(b => b.BookId == bookId).ConfigureAwait(false);
        }

        public async Task<bool> AddBookAsync(BookRequestDto bookRequestDto)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var book = BookMapper.MapToBook(bookRequestDto);
            try
            {
                await dbContext.Books.AddAsync(book).ConfigureAwait(false);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding book: {ex.Message}");
                return false;
            }
        }

        public async Task<List<BookResponseDto?>> GetAllBooksAsync()
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var books = await dbContext.Books.AsNoTracking().ToListAsync().ConfigureAwait(false);
            return books.Select(BookMapper.MapToBookResponseDto).ToList();
        }

        public async Task<BookResponseDto?> GetBookByIdAsync(int bookId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var book = await dbContext.Books.FindAsync(bookId).ConfigureAwait(false);
            return book == null ? null : BookMapper.MapToBookResponseDto(book);
        }

        public async Task<bool> UpdateBookAsync(int bookId, BookRequestDto bookRequestDto)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var book = await dbContext.Books.FindAsync(bookId).ConfigureAwait(false);

            if (book == null)
                return false;

            book.Title = bookRequestDto.Title;
            book.Author = bookRequestDto.Author;
            book.BookGenre = bookRequestDto.BookGenre;
            book.Isbn = bookRequestDto.Isbn;
            book.SellingPrice = bookRequestDto.SellingPrice;
            book.StockQuantity = bookRequestDto.StockQuantity;

            try
            {
                dbContext.Books.Update(book);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating book {bookId}: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteBookAsync(int bookId)
        {
            using var dbContext = _contextFactory.CreateDbContext();
            var book = await dbContext.Books.FindAsync(bookId).ConfigureAwait(false);

            if (book == null)
                return false;

            try
            {
                dbContext.Books.Remove(book);
                await dbContext.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting book {bookId}: {ex.Message}");
                return false;
            }
        }
    }
}
