using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public class PublisherRepository : BaseRepository
    {
        public PublisherRepository(IConfiguration configuration): base(configuration)
        {          

        }

        public async Task<IEnumerable<SelectListItem>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT PublisherId AS [Value], PublisherName AS [Text] FROM Publishers;";
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
