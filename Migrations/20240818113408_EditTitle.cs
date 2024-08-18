using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF.InitialMigration.Migrations
{
    /// <inheritdoc />
    public partial class EditTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Schedules",
                newName: "TiTle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TiTle",
                table: "Schedules",
                newName: "Title");
        }
    }
}
