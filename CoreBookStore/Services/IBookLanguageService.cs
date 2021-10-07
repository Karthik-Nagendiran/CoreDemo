using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public interface IBookLanguageService
    {
        Task<IEnumerable<SelectListItem>> GetBookLanguages();
    }
}
