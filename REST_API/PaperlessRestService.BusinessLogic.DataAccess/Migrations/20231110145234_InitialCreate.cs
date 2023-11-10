using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PaperlessRestService.BusinessLogic.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionNames",
                columns: table => new
                {
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionNames", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    DateJoined = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsStaff = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsSuperuser = table.Column<bool>(type: "boolean", nullable: false),
                    Groups = table.Column<int[]>(type: "integer[]", nullable: true),
                    UserPermissions = table.Column<string[]>(type: "text[]", nullable: true),
                    InheritedPermissions = table.Column<string[]>(type: "text[]", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroupMappings",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    PermissionName = table.Column<string>(type: "text", nullable: false),
                    GroupId1 = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroupMappings", x => new { x.GroupId, x.PermissionName });
                    table.ForeignKey(
                        name: "FK_PermissionGroupMappings_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermissionGroupMappings_Groups_GroupId1",
                        column: x => x.GroupId1,
                        principalTable: "Groups",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PermissionGroupMappings_PermissionNames_PermissionName",
                        column: x => x.PermissionName,
                        principalTable: "PermissionNames",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Correspondents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: true),
                    Match = table.Column<string>(type: "text", nullable: true),
                    MatchingAlgorithm = table.Column<int>(type: "integer", nullable: false),
                    IsInsensitive = table.Column<bool>(type: "boolean", nullable: false),
                    Owner = table.Column<int>(type: "integer", nullable: false),
                    LastCorrespondentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correspondents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correspondents_Correspondents_LastCorrespondentsId",
                        column: x => x.LastCorrespondentsId,
                        principalTable: "Correspondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Correspondents_Users_Owner",
                        column: x => x.Owner,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DocumentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Match = table.Column<string>(type: "text", nullable: true),
                    MatchingAlgorithm = table.Column<int>(type: "integer", nullable: true),
                    IsInsensitive = table.Column<bool>(type: "boolean", nullable: true),
                    Document_Count = table.Column<int>(type: "integer", nullable: false),
                    Owner = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DocumentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DocumentTypes_Users_Owner",
                        column: x => x.Owner,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GroupUserMappings",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUserMappings", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_GroupUserMappings_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GroupUserMappings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created_Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Added = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Archive_Serial_Number = table.Column<string>(type: "text", nullable: true),
                    Original_File_Name = table.Column<string>(type: "text", nullable: true),
                    Archived_File_Name = table.Column<string>(type: "text", nullable: true),
                    Storage_Path = table.Column<int>(type: "integer", nullable: true),
                    User_Can_Change = table.Column<bool>(type: "boolean", nullable: false),
                    CorrespondentId = table.Column<int>(type: "integer", nullable: false),
                    DocumentTypeId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Correspondents_CorrespondentId",
                        column: x => x.CorrespondentId,
                        principalTable: "Correspondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_DocumentTypes_DocumentTypeId",
                        column: x => x.DocumentTypeId,
                        principalTable: "DocumentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documents_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    DocumentId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Note = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => new { x.Id, x.DocumentId });
                    table.ForeignKey(
                        name: "FK_Notes_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Documents_Id",
                        column: x => x.Id,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Notes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Correspondents_LastCorrespondentsId",
                table: "Correspondents",
                column: "LastCorrespondentsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Correspondents_Owner",
                table: "Correspondents",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_CorrespondentId",
                table: "Documents",
                column: "CorrespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_DocumentTypeId",
                table: "Documents",
                column: "DocumentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_OwnerId",
                table: "Documents",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DocumentTypes_Owner",
                table: "DocumentTypes",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "IX_GroupUserMappings_UserId",
                table: "GroupUserMappings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DocumentId",
                table: "Notes",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroupMappings_GroupId1",
                table: "PermissionGroupMappings",
                column: "GroupId1");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroupMappings_PermissionName",
                table: "PermissionGroupMappings",
                column: "PermissionName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GroupUserMappings");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "PermissionGroupMappings");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "PermissionNames");

            migrationBuilder.DropTable(
                name: "Correspondents");

            migrationBuilder.DropTable(
                name: "DocumentTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
