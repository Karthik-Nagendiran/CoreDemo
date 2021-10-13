using CoreBookStore.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<SelectListItem>> GetAllAuthors();
        Task<List<Author>> GetAuthorsAsync();
        Task<int> CreateAuthorAsync(Author author);
        Task<int> UpdateAuhtorAsync(Author author);
        Task<bool> DeleteAuthorAsync(Author author);
        Task<Author> GetAuthorByIdAsync(int id);
    }
}
