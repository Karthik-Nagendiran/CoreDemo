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
                var query = @"INSERT INTO Books (Title, ISBN, LanguageId, PublisherId, AuthorId, Pages, PublicationDate, IsDeleted, CreatedOn, ModifiedOn, CreatedBy, ModifiedBy)
                                VALUES (@Title, @ISBN, @LanguageId, @PublisherId, @AuthorId, @Pages, @PublicationDate, @IsDeleted, @CreatedOn, @ModifiedOn, @CreatedBy, @ModifiedBy);";

                var parameters = new DynamicParameters();
                parameters.Add("Title", entity.Title, DbType.String);
                parameters.Add("ISBN", entity.ISBN, DbType.String);
                parameters.Add("LanguageId", entity.LanguageId, DbType.Int32);
                parameters.Add("PublisherId", entity.PublisherId, DbType.Int32);
                parameters.Add("AuthorId", entity.AuthorId, DbType.Int32);
                parameters.Add("Pages", entity.Pages, DbType.Int32);
                parameters.Add("PublicationDate", entity.PublicationDate, DbType.DateTime);
                parameters.Add("IsDeleted", false, DbType.Boolean);
                parameters.Add("CreatedOn", entity.CreatedOn, DbType.DateTime);
                parameters.Add("ModifiedOn", entity.ModifiedOn, DbType.DateTime);
                parameters.Add("CreatedBy", entity.CreatedBy, DbType.String);
                parameters.Add("ModifiedBy", entity.ModifiedBy, DbType.String);


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

        public async Task<int> DeleteAsync(Book entity)
        {
            try
            {
                var query = "DELETE FROM Books WHERE BookId = @BookId";

                var parameters = new DynamicParameters();
                parameters.Add("BookId", entity.BookId, DbType.Int32);

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

        public async Task<List<Book>> GetAllAsync()
        {
            try
            {
                var query = @"SELECT B.BookId, B.Title, B.ISBN, B.Pages, b.PublicationDate, B.LanguageId, BL.LanguageName, B.PublisherId, P.PublisherName, B.AuthorId, A.AuthorName,
                                B.CreatedBy, B.CreatedOn, B.ModifiedBy, B.ModifiedOn FROM Books B
                                LEFT JOIN BookLanguages BL ON BL.LanguageId = B.LanguageId
                                LEFT JOIN Publishers P ON P.PublisherId = B.PublisherId
                                LEFT JOIN Authors A ON A.AuthorId = B.AuthorId
                                WHERE B.IsDeleted = 0 ORDER BY B.Title;";
                using (var connection = CreateConnection())
                {
                    var result = await connection.QueryAsync<Book, BookLanguage, Publisher, Author, Book>(query, (b, bl, p, a) =>
                    {
                        b.Language = bl;
                        b.Publisher = p;
                        b.Author = a;
                        return b;
                    }, splitOn: "LanguageId,PublisherId,AuthorId");
                    return result.ToList();
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
                var query = "SELECT * FROM Books WHERE BookId = @BookId";

                var parameters = new DynamicParameters();
                parameters.Add("BookId", id, DbType.Int32);

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
                var query = "UPDATE Books SET Title = @Title, ISBN = @ISBN, LanguageCode = @LanguageCode, Pages = @Pages, PublicationDate = @PublicationDate, PublisherId = @PublisherId WHERE BookId = @BookId";

                var parameters = new DynamicParameters();
                parameters.Add("Title", entity.Title, DbType.String);
                parameters.Add("ISBN", entity.ISBN, DbType.String);
                parameters.Add("LanguageCode", entity.Language.LanguageCode, DbType.Int32);
                parameters.Add("Pages", entity.Pages, DbType.Int32);
                parameters.Add("PublicationDate", entity.PublicationDate, DbType.DateTime);
                parameters.Add("PublisherId", entity.Publisher.PublisherId, DbType.Int32);
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
