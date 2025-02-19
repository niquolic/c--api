using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibraryAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "CategoryId", "Isbn", "PublishedYear", "PublisherId", "Title" },
                values: new object[,]
                {
                    { 1, "Robert C. Martin", 1, "9780132350884", 2008, 1, "Livre1" },
                    { 2, "Andrew Hunt", 2, "9780201616224", 2020, 2, "Livre 2" },
                    { 3, "Erich Gamma", 3, "9780201633610", 2019, 3, "Livre 3" },
                    { 4, "Martin Fowler", 4, "9780201485677", 2018, 4, "Livre 4" },
                    { 5, "Steve McConnell", 5, "9780735619678", 2022, 5, "Livre 5" },
                    { 6, "Steve McConnell 2", 1, "9780735619679", 2022, 1, "Livre 6" },
                    { 7, "Steve McConnell 3", 2, "9780735619680", 2022, 2, "Livre 7" },
                    { 8, "Steve McConnell 4", 3, "9780735619681", 2022, 3, "Livre 8" },
                    { 9, "Steve McConnell 5", 4, "9780735619682", 2022, 4, "Livre 9" },
                    { 10, "Steve McConnell 6", 5, "9780735619683", 2022, 5, "Livre 10" }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Romantique" },
                    { 3, "Thriller" },
                    { 4, "Biographie" },
                    { 5, "Histoire" }
                });

            migrationBuilder.InsertData(
                table: "loans",
                columns: new[] { "Id", "BookId", "BorrowDate", "BorrowerName", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client 1", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client 2", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client 2", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client 3", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Client 4", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "publishers",
                columns: new[] { "Id", "ContactEmail", "FoundedYear", "Name" },
                values: new object[,]
                {
                    { 1, "johndoe@gmail.com", 2000, "John Doe" },
                    { 2, "thenry@gmail.com", 2005, "Thierry Henry corp" },
                    { 3, "zzidane@gmail.com", 2010, "Zinédine Zidane le z la vraie librairie" },
                    { 4, "creyel@gmail.com", 2015, "Colonel Reyel le flopesque libraire" },
                    { 5, "renetaupe@gmail.com", 2020, "René la taupe le goat du livre" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { 1, "client1@gmail.com", "Client 1", "Lecteur" },
                    { 2, "client2@gmail.com", "Client 2", "Lecteur" },
                    { 3, "client3@gmail.com", "Client 3", "Lecteur" },
                    { 4, "client4@gmail.com", "Client 4", "Lecteur" },
                    { 5, "admin@gmail.com", "Administrateur 1", "Administrateur" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "loans",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "loans",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "loans",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "loans",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "loans",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
