using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestWithASPNET.Migrations
{
    public partial class DepartamentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<int>(
                name: "DepartamentId",
                table: "tb_user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartamentIdDepartament",
                table: "tb_user",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtExclused",
                table: "tb_user",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DtInclused",
                table: "tb_user",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "tb_departament",
                columns: table => new
                {
                    IdDepartament = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NameDepartament = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DesDepartament = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DtInclused = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DtExclused = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departament", x => x.IdDepartament);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_DepartamentId",
                table: "tb_user",
                column: "DepartamentId");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_DepartamentIdDepartament",
                table: "tb_user",
                column: "DepartamentIdDepartament");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_departament_DepartamentId",
                table: "tb_user",
                column: "DepartamentId",
                principalTable: "tb_departament",
                principalColumn: "IdDepartament",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_user_tb_departament_DepartamentIdDepartament",
                table: "tb_user",
                column: "DepartamentIdDepartament",
                principalTable: "tb_departament",
                principalColumn: "IdDepartament",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_departament_DepartamentId",
                table: "tb_user");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_user_tb_departament_DepartamentIdDepartament",
                table: "tb_user");

            migrationBuilder.DropTable(
                name: "tb_departament");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_DepartamentId",
                table: "tb_user");

            migrationBuilder.DropIndex(
                name: "IX_tb_user_DepartamentIdDepartament",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "DepartamentId",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "DepartamentIdDepartament",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "DtExclused",
                table: "tb_user");

            migrationBuilder.DropColumn(
                name: "DtInclused",
                table: "tb_user");

            migrationBuilder.AddColumn<string>(
                name: "Departament",
                table: "tb_user",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "");
        }
    }
}
