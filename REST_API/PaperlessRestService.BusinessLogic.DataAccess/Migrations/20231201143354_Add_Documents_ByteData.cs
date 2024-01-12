using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaperlessRestService.BusinessLogic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Add_Documents_ByteData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "Documents",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "Documents");
        }
    }
}
