using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechBlog.Data.Migrations
{
    /// <inheritdoc />
    public partial class PostModelAddedPhotoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Posts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Posts");
        }
    }
}
