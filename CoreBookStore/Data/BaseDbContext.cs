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
        }

        DbSet<Book> Books { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<BookLanguage> BookLanguages { get; set; }
        DbSet<Publisher> Publishers { get; set; }
        DbSet<BookAuthor> BookAuthors { get; set; }
    }
}
