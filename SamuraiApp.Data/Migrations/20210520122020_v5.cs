using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SamuraiApp.Data.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "purchaseorder",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    supplier_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    supply_date = table.Column<string>(nullable: true),
                    productsproduct_id = table.Column<int>(nullable: true),
                    supplierssupplier_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchaseorder", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_purchaseorder_product_productsproduct_id",
                        column: x => x.productsproduct_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_purchaseorder_supplier_supplierssupplier_id",
                        column: x => x.supplierssupplier_id,
                        principalTable: "supplier",
                        principalColumn: "supplier_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorder_productsproduct_id",
                table: "purchaseorder",
                column: "productsproduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorder_supplierssupplier_id",
                table: "purchaseorder",
                column: "supplierssupplier_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseorder");
        }
    }
}
