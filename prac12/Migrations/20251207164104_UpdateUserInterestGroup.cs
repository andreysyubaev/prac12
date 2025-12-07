using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace prac12.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserInterestGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "UserInterestGroups",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "UserInterestGroups");
        }
    }
}
