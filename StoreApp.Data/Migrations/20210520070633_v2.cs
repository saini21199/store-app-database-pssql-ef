using Microsoft.EntityFrameworkCore.Migrations;

namespace SamuraiApp.Data.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_staffs_addresses_address_id",
                table: "staffs");

            migrationBuilder.DropForeignKey(
                name: "FK_staffs_roles_role_id",
                table: "staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staffs",
                table: "staffs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_roles",
                table: "roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_addresses",
                table: "addresses");

            migrationBuilder.RenameTable(
                name: "staffs",
                newName: "staff");

            migrationBuilder.RenameTable(
                name: "roles",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "addresses",
                newName: "address");

            migrationBuilder.RenameIndex(
                name: "IX_staffs_role_id",
                table: "staff",
                newName: "IX_staff_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_staffs_address_id",
                table: "staff",
                newName: "IX_staff_address_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_staff",
                table: "staff",
                column: "staff_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_role",
                table: "role",
                column: "role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_address",
                table: "address",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_staff_address_address_id",
                table: "staff",
                column: "address_id",
                principalTable: "address",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staff_role_role_id",
                table: "staff",
                column: "role_id",
                principalTable: "role",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_staff_address_address_id",
                table: "staff");

            migrationBuilder.DropForeignKey(
                name: "FK_staff_role_role_id",
                table: "staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_staff",
                table: "staff");

            migrationBuilder.DropPrimaryKey(
                name: "PK_role",
                table: "role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_address",
                table: "address");

            migrationBuilder.RenameTable(
                name: "staff",
                newName: "staffs");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "roles");

            migrationBuilder.RenameTable(
                name: "address",
                newName: "addresses");

            migrationBuilder.RenameIndex(
                name: "IX_staff_role_id",
                table: "staffs",
                newName: "IX_staffs_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_staff_address_id",
                table: "staffs",
                newName: "IX_staffs_address_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_staffs",
                table: "staffs",
                column: "staff_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_roles",
                table: "roles",
                column: "role_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_addresses",
                table: "addresses",
                column: "address_id");

            migrationBuilder.AddForeignKey(
                name: "FK_staffs_addresses_address_id",
                table: "staffs",
                column: "address_id",
                principalTable: "addresses",
                principalColumn: "address_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_staffs_roles_role_id",
                table: "staffs",
                column: "role_id",
                principalTable: "roles",
                principalColumn: "role_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
