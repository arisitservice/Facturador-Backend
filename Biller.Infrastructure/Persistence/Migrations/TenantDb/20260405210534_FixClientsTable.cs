using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Biller.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class FixClientsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_TaxRegimes_TaxRegimeId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_TaxRegimeId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CanEmitBill",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TaxAddress",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "TaxRegimeId",
                table: "Clients");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Clients",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Clients",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Clients",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Clients",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ClientTaxInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    BusinessName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TaxId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Default = table.Column<bool>(type: "boolean", nullable: false),
                    ClientId = table.Column<int>(type: "integer", nullable: false),
                    TaxRegimeId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTaxInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientTaxInfos_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClientTaxInfos_TaxRegimes_TaxRegimeId",
                        column: x => x.TaxRegimeId,
                        principalTable: "TaxRegimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientTaxInfos_ClientId",
                table: "ClientTaxInfos",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTaxInfos_TaxRegimeId",
                table: "ClientTaxInfos",
                column: "TaxRegimeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Clients");

            migrationBuilder.AddColumn<string>(
                name: "BusinessName",
                table: "Clients",
                type: "character varying(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "CanEmitBill",
                table: "Clients",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "Clients",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxAddress",
                table: "Clients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TaxId",
                table: "Clients",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TaxRegimeId",
                table: "Clients",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clients_TaxRegimeId",
                table: "Clients",
                column: "TaxRegimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_TaxRegimes_TaxRegimeId",
                table: "Clients",
                column: "TaxRegimeId",
                principalTable: "TaxRegimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
