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
        public async Task<IEnumerable<SelectListItem>> GetAllAuthors()
        {
            return await _authorRepository.GetAllAuthors();
        }

        public async Task<List<Author>> GetAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }
    }
}
