using CoreBookStore.Models;
using CoreBookStore.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly AuthorRepository _authorRepository;

        public AuthorService(AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<int> CreateAuthorAsync(Author author)
        {
            return await _authorRepository.CreateAsync(author);
        }

        public Task<bool> DeleteAuthorAsync(Author author)
        {
            return _authorRepository.DeleteAsync(author);
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        public Task<Author> GetAuthorByIdAsync(int id)
        {
            return _authorRepository.GetByIdAsync(id);
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public Task<int> UpdateAuhtorAsync(Author author)
        {
            return _authorRepository.UpdateAsync(author);
        }
    }
}
