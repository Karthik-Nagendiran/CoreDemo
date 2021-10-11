using CoreBookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreBookStore.Data
{
    public class BaseDbContext : DbContext
    {
        public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookLanguage>().HasData(
                    new BookLanguage { LanguageId = 1, LanguageName = "English", CultureName = "en-US", LanguageCode = "1033" },
                    new BookLanguage { LanguageId = 2, LanguageName = "English", CultureName = "en-GB", LanguageCode = "2057" },
                    new BookLanguage { LanguageId = 3, LanguageName = "French", CultureName = "fr-FR", LanguageCode = "1036" },
                    new BookLanguage { LanguageId = 4, LanguageName = "Italian", CultureName = "it-IT", LanguageCode = "1040" },
                    new BookLanguage { LanguageId = 5, LanguageName = "Spanish", CultureName = "es-ES", LanguageCode = "3082" },
                    new BookLanguage { LanguageId = 6, LanguageName = "German", CultureName = "de-DE", LanguageCode = "1031" },
                    new BookLanguage { LanguageId = 7, LanguageName = "Arabic", CultureName = "ar-AE", LanguageCode = "14337" },
                    new BookLanguage { LanguageId = 8, LanguageName = "Russian", CultureName = "ru-RU", LanguageCode = "1049" }
                );

            modelBuilder.Entity<Author>().HasData(
                    new  Author { AuthorId = 1, AuthorName = "Ellen Clifford" },
                    new Author { AuthorId = 2, AuthorName = "Felicity Fenton" },
                    new Author { AuthorId = 3, AuthorName = "Grace Bonney" },
                    new Author { AuthorId = 4, AuthorName = "Isabel Yap" },
                    new Author { AuthorId = 5, AuthorName = "Maeve Kelly" },
                    new Author { AuthorId = 6, AuthorName = "McCormack" },
                    new Author { AuthorId = 7, AuthorName = "Nial Bourke" },
                    new Author { AuthorId = 8, AuthorName = "Sarah Rees Brennan" },
                    new Author { AuthorId = 9, AuthorName = "Vinayak Varma" }
                );

            modelBuilder.Entity<Publisher>().HasData(
                    new Publisher { PublisherId = 1, PublisherName = "Artisan Books" },
                    new Publisher { PublisherId = 2, PublisherName = "Future Tense Books" },
                    new Publisher { PublisherId = 3, PublisherName = "Pratham Books" },
                    new Publisher { PublisherId = 4, PublisherName = "Small Beer Press" },
                    new Publisher { PublisherId = 5, PublisherName = "Tramp Press" },
                    new Publisher { PublisherId = 6, PublisherName = "Zed Books" }
                );
        }

        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<BookLanguage> BookLanguages { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
