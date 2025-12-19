using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiAdvance.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatedConfiguations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Brands",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "fgdskjda  fsabfkjsa",
                oldClrType: typeof(string),
                oldType: "nvarchar(400)",
                oldMaxLength: 400,
                oldDefaultValue: "fgdskjda  fsabfkjsa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Brands",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Brands",
                type: "nvarchar(400)",
                maxLength: 400,
                nullable: false,
                defaultValue: "fgdskjda  fsabfkjsa",
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldDefaultValue: "fgdskjda  fsabfkjsa");
        }
    }
}
