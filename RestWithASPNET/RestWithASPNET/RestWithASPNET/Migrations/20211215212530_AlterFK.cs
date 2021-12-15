using Microsoft.EntityFrameworkCore.Migrations;

namespace RestWithASPNET.Migrations
{
    public partial class AlterFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropIndex(
                name: "IX_tb_user_DepartamentIdDepartament",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "DepartamentIdDepartament",
                table: "tb_user");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartamentIdDepartament",
                table: "tb_user",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_DepartamentIdDepartament",
                table: "tb_user",
                column: "DepartamentIdDepartament");

        }
    }
}
