using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace SamuraiApp.Data.Migrations
{
    public partial class v6 : Migration
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
                      supply_date = table.Column<DateTime>(nullable: true),
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
            migrationBuilder.DropForeignKey(
                name: "FK_purchaseorder_product_productsproduct_id",
                table: "purchaseorder");

            migrationBuilder.DropForeignKey(
                name: "FK_purchaseorder_supplier_supplierssupplier_id",
                table: "purchaseorder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_purchaseorder",
                table: "purchaseorder");

            migrationBuilder.DropIndex(
                name: "IX_purchaseorder_productsproduct_id",
                table: "purchaseorder");

            migrationBuilder.DropIndex(
                name: "IX_purchaseorder_supplierssupplier_id",
                table: "purchaseorder");

            migrationBuilder.DropColumn(
                name: "productsproduct_id",
                table: "purchaseorder");

            migrationBuilder.DropColumn(
                name: "supplierssupplier_id",
                table: "purchaseorder");

            migrationBuilder.RenameTable(
                name: "purchaseorder",
                newName: "porder");

            migrationBuilder.AddColumn<int>(
                name: "supplier_id",
                table: "product",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "supply_date",
                table: "porder",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "order_id",
                table: "porder",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_porder",
                table: "porder",
                columns: new[] { "supplier_id", "product_id" });

            migrationBuilder.CreateIndex(
                name: "IX_product_supplier_id",
                table: "product",
                column: "supplier_id");

            migrationBuilder.CreateIndex(
                name: "IX_porder_product_id",
                table: "porder",
                column: "product_id");

            migrationBuilder.AddForeignKey(
                name: "FK_porder_product_product_id",
                table: "porder",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_porder_supplier_supplier_id",
                table: "porder",
                column: "supplier_id",
                principalTable: "supplier",
                principalColumn: "supplier_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_supplier_supplier_id",
                table: "product",
                column: "supplier_id",
                principalTable: "supplier",
                principalColumn: "supplier_id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseorder");

            migrationBuilder.DropForeignKey(
                name: "FK_porder_product_product_id",
                table: "porder");

            migrationBuilder.DropForeignKey(
                name: "FK_porder_supplier_supplier_id",
                table: "porder");

            migrationBuilder.DropForeignKey(
                name: "FK_product_supplier_supplier_id",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_supplier_id",
                table: "product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_porder",
                table: "porder");

            migrationBuilder.DropIndex(
                name: "IX_porder_product_id",
                table: "porder");

            migrationBuilder.DropColumn(
                name: "supplier_id",
                table: "product");

            migrationBuilder.RenameTable(
                name: "porder",
                newName: "purchaseorder");

            migrationBuilder.AlterColumn<string>(
                name: "supply_date",
                table: "purchaseorder",
                type: "text",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<int>(
                name: "order_id",
                table: "purchaseorder",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "productsproduct_id",
                table: "purchaseorder",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "supplierssupplier_id",
                table: "purchaseorder",
                type: "integer",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_purchaseorder",
                table: "purchaseorder",
                column: "order_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorder_productsproduct_id",
                table: "purchaseorder",
                column: "productsproduct_id");

            migrationBuilder.CreateIndex(
                name: "IX_purchaseorder_supplierssupplier_id",
                table: "purchaseorder",
                column: "supplierssupplier_id");

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseorder_product_productsproduct_id",
                table: "purchaseorder",
                column: "productsproduct_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_purchaseorder_supplier_supplierssupplier_id",
                table: "purchaseorder",
                column: "supplierssupplier_id",
                principalTable: "supplier",
                principalColumn: "supplier_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
