using Microsoft.EntityFrameworkCore.Migrations;

namespace CSAMS.Migrations
{
    public partial class AddMissingField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Label",
                table: "UserSubmissions",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Label",
                table: "UserSubmissions");
        }
    }
}
