using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrmModel.Migrations
{
    public partial class _202121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8_general_ci"),
                    ClientId = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci"),
                    ClientSecret = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    ConcurrencyToken = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci"),
                    ConsentType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    DisplayNames = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Permissions = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    PostLogoutRedirectUris = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    RedirectUris = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Requirements = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8_general_ci"),
                    ConcurrencyToken = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Descriptions = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    DisplayName = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    DisplayNames = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true, collation: "utf8_general_ci"),
                    Properties = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Resources = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "openiddicttokens",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8_general_ci"),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8_general_ci"),
                    applicationid = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false, collation: "utf8_general_ci"),
                    authorizationid = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true, collation: "utf8_general_ci"),
                    concurrencytoken = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8_general_ci"),
                    creationdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    expirationdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    payload = table.Column<string>(type: "varchar(3000)", maxLength: 3000, nullable: true, collation: "utf8_general_ci"),
                    properties = table.Column<string>(type: "varchar(2000)", maxLength: 2000, nullable: true, collation: "utf8_general_ci"),
                    redemptiondate = table.Column<DateTime>(type: "datetime", nullable: true),
                    referenceid = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true, collation: "utf8_general_ci"),
                    subject = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false, collation: "utf8_general_ci"),
                    type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_openiddicttokens", x => x.id);
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false, collation: "utf8_general_ci"),
                    ApplicationId = table.Column<string>(type: "varchar(255)", nullable: true, collation: "utf8_general_ci"),
                    ConcurrencyToken = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci"),
                    CreationDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Properties = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Scopes = table.Column<string>(type: "longtext", nullable: true, collation: "utf8_general_ci"),
                    Status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci"),
                    Subject = table.Column<string>(type: "varchar(400)", maxLength: 400, nullable: true, collation: "utf8_general_ci"),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true, collation: "utf8_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                })
                .Annotation("Relational:Collation", "utf8_general_ci");

          
            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "openiddictapplications");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "openiddicttokens");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");
        }
    }
}
