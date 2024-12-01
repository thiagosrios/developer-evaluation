using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddDatabaseSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Branchs",
                columns: new[] { "Name" },
                values: new object[,]
                {
                    { "Filial 1" },
                    { "Filial 2" }
                }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "UnitPrice" },
                values: new object[,]
                {
                    { "Beer A", 5.90 },
                    { "Beer B", 10 }
                }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Name", "Document" },
                values: new object[,]
                {
                    { "Client 1", "00011122233" },
                    { "Cliente 2", "44455566677" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {            
        }
    }
}
