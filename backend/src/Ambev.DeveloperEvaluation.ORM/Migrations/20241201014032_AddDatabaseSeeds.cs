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
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("35ffdeff-a387-4041-94a8-027ce91fbca0"), "Filial 1" }
                }
            );

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Name", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("2a1d48d3-ebd8-48a1-861b-74202a917ae6"), "Beer A", 5.90 },
                    { new Guid("d79ddb11-883d-4a85-9dfd-24a9aa0e1394"), "Beer B", 10 }
                }
            );

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name", "Document" },
                values: new object[,]
                {
                    { new Guid("7016b985-ee2e-41be-ab99-84280ec4bf89"), "Client 1", "00011122233" },
                    { new Guid("58ef212f-7aba-4a5c-9357-674bc0217e78"), "Cliente 2", "44455566677" }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {            
        }
    }
}
