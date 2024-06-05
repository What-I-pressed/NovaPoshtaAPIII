using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovaPoshtaAPIBleBla.Migrations
{
    /// <inheritdoc />
    public partial class RefpropertywasaddedtoPostOfficeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ref",
                table: "tblPostOffices",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ref",
                table: "tblPostOffices");
        }
    }
}
