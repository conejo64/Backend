using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Migrations
{
    public partial class add_Documents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserOriginId",
                table: "CaseEntities",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_UserOriginId",
                table: "CaseEntities",
                column: "UserOriginId");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseEntities_Users_UserOriginId",
                table: "CaseEntities",
                column: "UserOriginId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseEntities_Users_UserOriginId",
                table: "CaseEntities");

            migrationBuilder.DropIndex(
                name: "IX_CaseEntities_UserOriginId",
                table: "CaseEntities");

            migrationBuilder.DropColumn(
                name: "UserOriginId",
                table: "CaseEntities");
        }
    }
}
