using CoreBookStore.Models;
using Dapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public Task<int> CreateAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<SelectListItem>> GetAllAuthors()
        {
            try
            {
                var query = @"SELECT AuthorId As [Value], AuthorName AS [Text] From Authors WHERE IsDeleted = 0 ORDER BY AuthorName;";
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

        public async Task<List<Author>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT AuthorId, AuthorName From Authors WHERE IsDeleted = 0 ORDER BY AuthorName;";
                using (var connection = CreateConnection())
                {
                    var result = await connection.QueryAsync<Author>(query).ConfigureAwait(false);
                    return result.AsList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<Author> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Author entity)
        {
            throw new NotImplementedException();
        }

        Task<List<Author>> IRepository<Author>.GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
