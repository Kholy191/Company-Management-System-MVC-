using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kholy.IKEA.DAL.Data.Migrations
{
    /// <inheritdoc />
    public partial class RelationShipsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DepartmentID",
                table: "employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_employees_DepartmentID",
                table: "employees",
                column: "DepartmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_employees_departments_DepartmentID",
                table: "employees",
                column: "DepartmentID",
                principalTable: "departments",
                principalColumn: "ID",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_employees_departments_DepartmentID",
                table: "employees");

            migrationBuilder.DropIndex(
                name: "IX_employees_DepartmentID",
                table: "employees");

            migrationBuilder.DropColumn(
                name: "DepartmentID",
                table: "employees");
        }
    }
}
