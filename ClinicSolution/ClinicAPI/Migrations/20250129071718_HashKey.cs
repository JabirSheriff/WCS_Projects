using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicAPI.Migrations
{
    /// <inheritdoc />
    public partial class HashKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "HasKey",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasKey",
                table: "Users");
        }
    }
}
