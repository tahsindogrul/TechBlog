using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedToAboutAppuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "About",
                table: "Users");
        }
    }
}
