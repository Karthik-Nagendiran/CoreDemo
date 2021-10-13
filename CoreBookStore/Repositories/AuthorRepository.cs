using CoreBookStore.Models;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<int> CreateAsync(Author entity)
        {
            try
            {
                using var connection = CreateConnection();
                return (Convert.ToInt32(await connection.InsertAsync(entity)));

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<bool> DeleteAsync(Author entity)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return Task.FromResult(connection.Delete(entity));
                }

            }
            catch (Exception)
            {

                throw;
            }
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
            List<Author> authors = new List<Author>();
            try
            {
                //var query = @"SELECT AuthorId, AuthorName From Authors WHERE IsDeleted = 0 ORDER BY AuthorName;";
                //using (var connection = CreateConnection())
                //{
                //    var result = await connection.QueryAsync<Author>(query).ConfigureAwait(false);
                //    return result.AsList();
                //}

                using var connection = CreateConnection();                
                var result = await connection.GetAllAsync<Author>().ConfigureAwait(false);
                authors = result.OrderBy(a => a.AuthorName).ToList();
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex); 
            }

            return authors;
        }

        public Task<Author> GetByIdAsync(int id)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    return Task.FromResult(connection.Get<Author>(id));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<int> UpdateAsync(Author entity)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var result = connection.Update<Author>(entity);
                    return Task.FromResult(result ? entity.AuthorId : 0); 
                }

            }
            catch (Exception)
            {

                throw;
            }
        }        
    }
}
