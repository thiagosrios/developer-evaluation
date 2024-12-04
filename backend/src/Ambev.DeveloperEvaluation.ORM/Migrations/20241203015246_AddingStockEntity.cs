using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ambev.DeveloperEvaluation.ORM.Migrations
{
    /// <inheritdoc />
    public partial class AddingStockEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    BranchId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    AvailableQuantity = table.Column<int>(type: "integer", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => new { x.BranchId, x.ProductId });
                });

            var branchId = new Guid("35ffdeff-a387-4041-94a8-027ce91fbca0");
            migrationBuilder.InsertData(
                table: "Stock",
                columns: new[] { "ProductId", "BranchId", "AvailableQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("2a1d48d3-ebd8-48a1-861b-74202a917ae6"), branchId, 20, DateTime.UtcNow },
                    { new Guid("d79ddb11-883d-4a85-9dfd-24a9aa0e1394"), branchId, 10, DateTime.UtcNow }
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stock");
        }
    }
}
