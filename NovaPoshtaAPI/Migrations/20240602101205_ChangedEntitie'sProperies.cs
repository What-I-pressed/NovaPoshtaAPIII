using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovaPoshtaAPIBleBla.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEntitiesProperies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "tblCities",
                newName: "Ref");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "tblCities",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Area",
                table: "tblAreas",
                newName: "Ref");

            migrationBuilder.AddColumn<int>(
                name: "AreaId",
                table: "tblCities",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "tblAreas",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "tblCities");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "tblAreas");

            migrationBuilder.RenameColumn(
                name: "Ref",
                table: "tblCities",
                newName: "CityId");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tblCities",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Ref",
                table: "tblAreas",
                newName: "Area");
        }
    }
}
