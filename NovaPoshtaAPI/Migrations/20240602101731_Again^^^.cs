using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NovaPoshtaAPIBleBla.Migrations
{
    /// <inheritdoc />
    public partial class Again : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tblCities_AreaId",
                table: "tblCities",
                column: "AreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblCities_tblAreas_AreaId",
                table: "tblCities",
                column: "AreaId",
                principalTable: "tblAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblCities_tblAreas_AreaId",
                table: "tblCities");

            migrationBuilder.DropIndex(
                name: "IX_tblCities_AreaId",
                table: "tblCities");
        }
    }
}
