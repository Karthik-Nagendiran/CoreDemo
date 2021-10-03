using CoreBookStore.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBookStore.Repositories
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<int> CreateAsync(Book entity)
        {
            try
            {
                var query = "INSERT INTO Books (Title, ISBN, LangId, Pages, PublicationDate, PublisherId) VALUES (@Title, @ISBN, @LangId, @Pages, @PublicationDate, @PublisherId)";

                var parameters = new DynamicParameters();
                parameters.Add("Title", entity.Title, DbType.String);
                parameters.Add("ISBN", entity.ISBN, DbType.String);
                parameters.Add("LangId", entity.LangId, DbType.Int32);
                parameters.Add("Pages", entity.Pages, DbType.Int32);
                parameters.Add("PublicationDate", entity.PublicationDate, DbType.DateTime);
                parameters.Add("PublisherId", entity.PublisherId, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public Task<int> DeleteAsync(Book entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                var query = "SELECT * FROM Books";
                using (var connection = CreateConnection())
                {
                    return (await connection.QueryAsync<Book>(query)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            try
            {
                var query = "SELECT * FROM Books WHERE Id = @Id";

                var parameters = new DynamicParameters();
                parameters.Add("Id", id, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.QueryFirstOrDefaultAsync<Book>(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<int> UpdateAsync(Book entity)
        {
            try
            {
                var query = "UPDATE Books SET Title = @Title, ISBN = @ISBN, LangId = @LangId, Pages = @Pages, PublicationDate = @PublicationDate, PublisherId = @PublisherId WHERE BookId = @BookId";

                var parameters = new DynamicParameters();
                parameters.Add("Title", entity.Title, DbType.String);
                parameters.Add("ISBN", entity.ISBN, DbType.String);
                parameters.Add("LangId", entity.LangId, DbType.Int32);
                parameters.Add("Pages", entity.Pages, DbType.Int32);
                parameters.Add("PublicationDate", entity.PublicationDate, DbType.DateTime);
                parameters.Add("PublisherId", entity.PublisherId, DbType.Int32);
                parameters.Add("Id", entity.BookId, DbType.Int32);

                using (var connection = CreateConnection())
                {
                    return (await connection.ExecuteAsync(query, parameters));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}
