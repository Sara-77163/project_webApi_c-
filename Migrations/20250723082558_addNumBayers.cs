using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace final_project.Migrations
{
    /// <inheritdoc />
    public partial class addNumBayers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_GiftCategories_CategoryId",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Users",
                newName: "Role");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Gifts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Gifts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumBuyers",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_GiftCategories_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "GiftCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gifts_GiftCategories_CategoryId",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Gifts");

            migrationBuilder.DropColumn(
                name: "NumBuyers",
                table: "Gifts");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Users",
                newName: "UserRole");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Gifts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Gifts_GiftCategories_CategoryId",
                table: "Gifts",
                column: "CategoryId",
                principalTable: "GiftCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
