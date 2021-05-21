using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class added_new_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "inventoryproduct_id",
                table: "product",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "inventory",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inventory", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_inventory_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_product_inventoryproduct_id",
                table: "product",
                column: "inventoryproduct_id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_inventory_inventoryproduct_id",
                table: "product",
                column: "inventoryproduct_id",
                principalTable: "inventory",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_inventory_inventoryproduct_id",
                table: "product");

            migrationBuilder.DropTable(
                name: "inventory");

            migrationBuilder.DropIndex(
                name: "IX_product_inventoryproduct_id",
                table: "product");

            migrationBuilder.DropColumn(
                name: "inventoryproduct_id",
                table: "product");
        }
    }
}
