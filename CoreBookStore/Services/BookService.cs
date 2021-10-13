using CoreBookStore.Models;
using CoreBookStore.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<int> CreateBookAsync(Book book)
        {
            return await _bookRepository.CreateAsync(book);
        }

        public async Task<bool> DeleteBookAsync(Book book)
        {
            return await _bookRepository.DeleteAsync(book);
        }

        public async Task<List<Book>> GetAllBooks()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task<int> UpdateBookAsync(Book book)
        {
            return await _bookRepository.UpdateAsync(book);
        }
    }
}
