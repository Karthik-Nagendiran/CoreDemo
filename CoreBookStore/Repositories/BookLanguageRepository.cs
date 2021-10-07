using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public class BookLanguageRepository : BaseRepository
    {
        public BookLanguageRepository(IConfiguration configuration) : base(configuration) 
        {

        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT LanguageCode AS [Value], LanguageName As [Text] FROM BookLanguages ORDER by LanguageName;";
                using (var connection = CreateConnection())
                {
                    var result = await connection.QueryAsync<SelectListItem>(query).ConfigureAwait(false);
                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
