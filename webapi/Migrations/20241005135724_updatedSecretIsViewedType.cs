using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class updatedSecretIsViewedType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(name: "IsViewed", table: "Secrets");
            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "Secrets",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "IsViewed", table: "Secrets");
            migrationBuilder.AddColumn<bool>(
                name: "IsViewed",
                table: "Secrets",
                type: "boolean",
                nullable: false,
                defaultValue: false
            );
        }
    }
}
