using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class createProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "Price", "Price100", "Price50", "Title" },
                values: new object[,]
                {
                    { 1, "Author 1", "Description 1", "ISBN1", 19.989999999999998, "14.99", 10.99, 12.99, "Book 1" },
                    { 2, "Author 2", "Description 2", "ISBN2", 24.989999999999998, "19.99", 15.99, 17.989999999999998, "Book 2" },
                    { 3, "Author 3", "Description 3", "ISBN3", 29.989999999999998, "24.99", 20.989999999999998, 22.989999999999998, "Book 3" },
                    { 4, "Author 4", "Description 4", "ISBN4", 34.990000000000002, "29.99", 25.989999999999998, 27.989999999999998, "Book 4" },
                    { 5, "Author 5", "Description 5", "ISBN5", 39.990000000000002, "34.99", 30.989999999999998, 32.990000000000002, "Book 5" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
