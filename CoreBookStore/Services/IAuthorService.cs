using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<SelectListItem>> GetAllAuthors();
    }
}
