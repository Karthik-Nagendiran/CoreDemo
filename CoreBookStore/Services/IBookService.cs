using CoreBookStore.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public interface IBookService
    {
        public Task<List<Book>> GetAllBooks();
        public Task<Book> GetBookById(int id);
        public Task<int> CreateBookAsync(Book book);
        public Task<int> UpdateBookAsync(Book book);
        public Task<int> DeleteBookAsync(Book book);
    }
}
