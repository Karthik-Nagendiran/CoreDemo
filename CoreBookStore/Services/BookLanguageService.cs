using CoreBookStore.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Services
{
    public class BookLanguageService : IBookLanguageService
    {
        private readonly BookLanguageRepository _bookLanguageRepository;

        public BookLanguageService(BookLanguageRepository bookLanguageRepository)
        {
            _bookLanguageRepository = bookLanguageRepository;
        }
        public async Task<IEnumerable<SelectListItem>> GetBookLanguages()
        {
            return await _bookLanguageRepository.GetAllAsync();
        }
    }
}
