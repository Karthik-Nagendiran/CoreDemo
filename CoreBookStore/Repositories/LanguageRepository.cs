using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public class LanguageRepository : BaseRepository
    {
        public LanguageRepository(IConfiguration configuration)
            : base(configuration)
        {

        }
        public async Task<IEnumerable<SelectListItem>> GetLanguages()
        {
            try
            {
                var query = "SELECT LanguageId As [Value], LanguageName AS [Text] FROM BookLanguages ORDER BY LanguageName;";
                using (var connection = CreateConnection())
                {
                   return await connection.QueryAsync<SelectListItem>(query).ConfigureAwait(false);                    
                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
