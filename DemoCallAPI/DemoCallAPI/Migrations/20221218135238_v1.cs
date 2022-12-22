using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemoCallAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartId = table.Column<string>(nullable: false),
                    DepartName = table.Column<string>(nullable: true),
                    TotalEmployees = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartId);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpId = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(nullable: true),
                    DepartId = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Salary = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpId);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepartId",
                        column: x => x.DepartId,
                        principalTable: "Department",
                        principalColumn: "DepartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Department_DepartName",
                table: "Department",
                column: "DepartName",
                unique: true,
                filter: "[DepartName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepartId",
                table: "Employee",
                column: "DepartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
