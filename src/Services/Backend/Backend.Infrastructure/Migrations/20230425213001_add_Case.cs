using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Infrastructure.Migrations
{
    public partial class add_Case : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Profiles_ProfileId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateTable(
                name: "CaseStatuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseStatusSecretaries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseStatusSecretaries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reminders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reminders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeRequirements",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeRequirements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CaseEntities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequirementNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceptionDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginDocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PhysicallyReceived = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitallyReceived = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SbsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JudgmentNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BrandId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DepartmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TypeRequirementId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Notification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransferDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReminderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReplyDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CaseStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ObservationDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaseStatusSecretaryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AcknowledgmentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExtensionRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewExtensionRequestDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ObservationExtension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseEntities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaseEntities_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_CaseStatuses_CaseStatusId",
                        column: x => x.CaseStatusId,
                        principalTable: "CaseStatuses",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_CaseStatusSecretaries_CaseStatusSecretaryId",
                        column: x => x.CaseStatusSecretaryId,
                        principalTable: "CaseStatusSecretaries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_OriginDocuments_OriginDocumentId",
                        column: x => x.OriginDocumentId,
                        principalTable: "OriginDocuments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_Reminders_ReminderId",
                        column: x => x.ReminderId,
                        principalTable: "Reminders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_TypeRequirements_TypeRequirementId",
                        column: x => x.TypeRequirementId,
                        principalTable: "TypeRequirements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CaseEntities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_BrandId",
                table: "CaseEntities",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_CaseStatusId",
                table: "CaseEntities",
                column: "CaseStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_CaseStatusSecretaryId",
                table: "CaseEntities",
                column: "CaseStatusSecretaryId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_DepartmentId",
                table: "CaseEntities",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_OriginDocumentId",
                table: "CaseEntities",
                column: "OriginDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_ProvinceId",
                table: "CaseEntities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_ReminderId",
                table: "CaseEntities",
                column: "ReminderId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_TypeRequirementId",
                table: "CaseEntities",
                column: "TypeRequirementId");

            migrationBuilder.CreateIndex(
                name: "IX_CaseEntities_UserId",
                table: "CaseEntities",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Profiles_ProfileId",
                table: "UserProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Profiles_ProfileId",
                table: "UserProfiles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles");

            migrationBuilder.DropTable(
                name: "CaseEntities");

            migrationBuilder.DropTable(
                name: "CaseStatuses");

            migrationBuilder.DropTable(
                name: "CaseStatusSecretaries");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Provinces");

            migrationBuilder.DropTable(
                name: "Reminders");

            migrationBuilder.DropTable(
                name: "TypeRequirements");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Profiles_ProfileId",
                table: "UserProfiles",
                column: "ProfileId",
                principalTable: "Profiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProfiles_Users_UserId",
                table: "UserProfiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
