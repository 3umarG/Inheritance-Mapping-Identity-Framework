using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TPH.Migrations
{
    public partial class ChangeDiscriminatorColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Discriminator",
                table: "AspNetUsers",
                newName: "User_Role");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_Role",
                table: "AspNetUsers",
                newName: "Discriminator");
        }
    }
}
