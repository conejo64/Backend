using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Migrations
{
    public partial class add_DocumentEntitiesCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Documnet64Name",
                table: "DocumentEntities",
                newName: "DocumentSource");

            migrationBuilder.AddColumn<string>(
                name: "Document64Name",
                table: "DocumentEntities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Document64Name",
                table: "DocumentEntities");

            migrationBuilder.RenameColumn(
                name: "DocumentSource",
                table: "DocumentEntities",
                newName: "Documnet64Name");
        }
    }
}
