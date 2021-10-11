using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreBookStore.Migrations
{
    public partial class BaseDBSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookAuthors",
                columns: table => new
                {
                    BookAuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookAuthors", x => x.BookAuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BookLanguages",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LanguageCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LanguageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CultureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookLanguages", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.PublisherId);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    LanguageId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Pages = table.Column<int>(type: "int", nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "AuthorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_BookLanguages_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "BookLanguages",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Books_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "PublisherId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "AuthorName", "CreatedBy", "CreatedOn", "IsDeleted", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 1, "Ellen Clifford", "", new DateTime(2021, 10, 11, 18, 25, 3, 583, DateTimeKind.Local).AddTicks(9997), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(19) },
                    { 2, "Felicity Fenton", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(702), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(704) },
                    { 3, "Grace Bonney", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(707), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(708) },
                    { 4, "Isabel Yap", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(709), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(710) },
                    { 5, "Maeve Kelly", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(711), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(712) },
                    { 6, "McCormack", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(713), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(714) },
                    { 7, "Nial Bourke", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(716), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(716) },
                    { 8, "Sarah Rees Brennan", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(718), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(719) },
                    { 9, "Vinayak Varma", "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(721), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(722) }
                });

            migrationBuilder.InsertData(
                table: "BookLanguages",
                columns: new[] { "LanguageId", "CreatedBy", "CreatedOn", "CultureName", "IsDeleted", "LanguageCode", "LanguageName", "ModifiedBy", "ModifiedOn" },
                values: new object[,]
                {
                    { 8, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3565), "ru-RU", false, "1049", "Russian", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3566) },
                    { 7, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3561), "ar-AE", false, "14337", "Arabic", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3562) },
                    { 6, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3559), "de-DE", false, "1031", "German", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3560) },
                    { 5, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3556), "es-ES", false, "3082", "Spanish", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3557) },
                    { 3, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3551), "fr-FR", false, "1036", "French", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3552) },
                    { 2, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3541), "en-GB", false, "2057", "English", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3548) },
                    { 1, "", new DateTime(2021, 10, 11, 18, 25, 3, 581, DateTimeKind.Local).AddTicks(1517), "en-US", false, "1033", "English", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(1310) },
                    { 4, "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3554), "it-IT", false, "1040", "Italian", "", new DateTime(2021, 10, 11, 18, 25, 3, 582, DateTimeKind.Local).AddTicks(3555) }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "PublisherId", "CreatedBy", "CreatedOn", "IsDeleted", "ModifiedBy", "ModifiedOn", "PublisherName" },
                values: new object[,]
                {
                    { 5, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1817), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1818), "Tramp Press" },
                    { 1, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1258), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1262), "Artisan Books" },
                    { 2, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1806), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1810), "Future Tense Books" },
                    { 3, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1812), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1813), "Pratham Books" },
                    { 4, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1814), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1815), "Small Beer Press" },
                    { 6, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1819), false, "", new DateTime(2021, 10, 11, 18, 25, 3, 584, DateTimeKind.Local).AddTicks(1820), "Zed Books" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId",
                table: "Books",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_LanguageId",
                table: "Books",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherId",
                table: "Books",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthors");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "BookLanguages");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
