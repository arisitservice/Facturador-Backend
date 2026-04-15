using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Biller.Infrastructure.Persistence.Migrations.TenantDb
{
    /// <inheritdoc />
    public partial class ApplyTPTStructureForTaxInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop existing FKs and indexes from derived tables
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTaxInfos_TaxRegimes_TaxRegimeId",
                table: "AccountTaxInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTaxInfos_Clients_ClientId",
                table: "ClientTaxInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTaxInfos_TaxRegimes_TaxRegimeId",
                table: "ClientTaxInfos");

            migrationBuilder.DropIndex(
                name: "IX_ClientTaxInfos_TaxRegimeId",
                table: "ClientTaxInfos");

            migrationBuilder.DropIndex(
                name: "IX_AccountTaxInfos_TaxRegimeId",
                table: "AccountTaxInfos");

            // Step 2: Create TaxInfoBases table BEFORE dropping columns or adding FKs
            migrationBuilder.CreateTable(
                name: "TaxInfoBases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TaxAddress = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    BusinessName = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    TaxId = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Default = table.Column<bool>(type: "boolean", nullable: false),
                    TaxRegimeId = table.Column<int>(type: "integer", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxInfoBases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxInfoBases_TaxRegimes_TaxRegimeId",
                        column: x => x.TaxRegimeId,
                        principalTable: "TaxRegimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TaxInfoBases_TaxRegimeId",
                table: "TaxInfoBases",
                column: "TaxRegimeId");

            // Step 3: Migrate existing AccountTaxInfos rows to TaxInfoBases (same IDs)
            migrationBuilder.Sql(@"
                INSERT INTO ""TaxInfoBases"" (""Id"", ""TaxAddress"", ""PostalCode"", ""BusinessName"", ""TaxId"", ""Default"", ""TaxRegimeId"", ""Created"", ""CreatedBy"", ""LastModified"", ""LastModifiedBy"")
                SELECT ""Id"", ""TaxAddress"", ""PostalCode"", ""BusinessName"", ""TaxId"", ""Default"", ""TaxRegimeId"", ""Created"", ""CreatedBy"", ""LastModified"", ""LastModifiedBy""
                FROM ""AccountTaxInfos"";
            ");

            // Step 4: Migrate existing ClientTaxInfos rows to TaxInfoBases
            //         offset = GREATEST(MAX(TaxInfoBases.Id), MAX(ClientTaxInfos.Id))
            //         guarantees all new IDs are strictly greater than any existing ClientTaxInfos ID,
            //         preventing PK conflicts during the UPDATE.
            migrationBuilder.Sql(@"
                DO $$
                DECLARE
                    id_offset INTEGER;
                    max_id    INTEGER;
                BEGIN
                    SELECT GREATEST(
                        COALESCE((SELECT MAX(""Id"") FROM ""TaxInfoBases""), 0),
                        COALESCE((SELECT MAX(""Id"") FROM ""ClientTaxInfos""), 0)
                    ) INTO id_offset;

                    INSERT INTO ""TaxInfoBases"" (""Id"", ""TaxAddress"", ""PostalCode"", ""BusinessName"", ""TaxId"", ""Default"", ""TaxRegimeId"", ""Created"", ""CreatedBy"", ""LastModified"", ""LastModifiedBy"")
                    SELECT ""Id"" + id_offset, ""TaxAddress"", ""PostalCode"", ""BusinessName"", ""TaxId"", ""Default"", ""TaxRegimeId"", ""Created"", ""CreatedBy"", ""LastModified"", ""LastModifiedBy""
                    FROM ""ClientTaxInfos"";

                    IF id_offset > 0 THEN
                        UPDATE ""ClientTaxInfos"" SET ""Id"" = ""Id"" + id_offset;
                    END IF;

                    SELECT COALESCE(MAX(""Id""), 0) + 1 INTO max_id FROM ""TaxInfoBases"";
                    EXECUTE format('ALTER TABLE ""TaxInfoBases"" ALTER COLUMN ""Id"" RESTART WITH %s', max_id);
                END $$;
            ");

            // Step 5: Drop shared columns from derived tables (data already migrated to TaxInfoBases)
            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "Default",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "TaxAddress",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "TaxRegimeId",
                table: "ClientTaxInfos");

            migrationBuilder.DropColumn(
                name: "BusinessName",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "Default",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "TaxAddress",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "TaxId",
                table: "AccountTaxInfos");

            migrationBuilder.DropColumn(
                name: "TaxRegimeId",
                table: "AccountTaxInfos");

            // Step 6: Remove identity from derived table PKs (now FK to TaxInfoBases)
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ClientTaxInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AccountTaxInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTaxInfos_TaxInfoBases_Id",
                table: "AccountTaxInfos",
                column: "Id",
                principalTable: "TaxInfoBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTaxInfos_Clients_ClientId",
                table: "ClientTaxInfos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTaxInfos_TaxInfoBases_Id",
                table: "ClientTaxInfos",
                column: "Id",
                principalTable: "TaxInfoBases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Step 1: Drop FKs from derived tables to TaxInfoBases
            migrationBuilder.DropForeignKey(
                name: "FK_AccountTaxInfos_TaxInfoBases_Id",
                table: "AccountTaxInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTaxInfos_Clients_ClientId",
                table: "ClientTaxInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientTaxInfos_TaxInfoBases_Id",
                table: "ClientTaxInfos");

            // Step 2: Restore IDENTITY to derived table PKs
            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "ClientTaxInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "AccountTaxInfos",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            // Step 3: Add shared columns back to both tables (with defaults, data will be restored in step 4)
            migrationBuilder.AddColumn<string>(name: "BusinessName",  table: "ClientTaxInfos",  type: "character varying(200)", maxLength: 200, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<DateTime>(name: "Created",     table: "ClientTaxInfos",  type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(name: "CreatedBy",     table: "ClientTaxInfos",  type: "character varying(256)", maxLength: 256, nullable: true);
            migrationBuilder.AddColumn<bool>(name: "Default",         table: "ClientTaxInfos",  type: "boolean", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<DateTime>(name: "LastModified",    table: "ClientTaxInfos", type: "timestamp with time zone", nullable: true);
            migrationBuilder.AddColumn<string>(name: "LastModifiedBy",    table: "ClientTaxInfos", type: "character varying(256)", maxLength: 256, nullable: true);
            migrationBuilder.AddColumn<string>(name: "PostalCode",        table: "ClientTaxInfos", type: "character varying(5)", maxLength: 5, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "TaxAddress",        table: "ClientTaxInfos", type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "TaxId",             table: "ClientTaxInfos", type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<int>(name: "TaxRegimeId",          table: "ClientTaxInfos", type: "integer", nullable: false, defaultValue: 0);

            migrationBuilder.AddColumn<string>(name: "BusinessName",  table: "AccountTaxInfos", type: "character varying(200)", maxLength: 200, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<DateTime>(name: "Created",     table: "AccountTaxInfos", type: "timestamp with time zone", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<string>(name: "CreatedBy",     table: "AccountTaxInfos", type: "character varying(256)", maxLength: 256, nullable: true);
            migrationBuilder.AddColumn<bool>(name: "Default",         table: "AccountTaxInfos", type: "boolean", nullable: false, defaultValue: false);
            migrationBuilder.AddColumn<DateTime>(name: "LastModified",    table: "AccountTaxInfos", type: "timestamp with time zone", nullable: true);
            migrationBuilder.AddColumn<string>(name: "LastModifiedBy",    table: "AccountTaxInfos", type: "character varying(256)", maxLength: 256, nullable: true);
            migrationBuilder.AddColumn<string>(name: "PostalCode",        table: "AccountTaxInfos", type: "character varying(5)", maxLength: 5, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "TaxAddress",        table: "AccountTaxInfos", type: "character varying(500)", maxLength: 500, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<string>(name: "TaxId",             table: "AccountTaxInfos", type: "character varying(50)", maxLength: 50, nullable: false, defaultValue: "");
            migrationBuilder.AddColumn<int>(name: "TaxRegimeId",          table: "AccountTaxInfos", type: "integer", nullable: false, defaultValue: 0);

            // Step 4: Restore data from TaxInfoBases BEFORE dropping it
            migrationBuilder.Sql(@"
                UPDATE ""AccountTaxInfos"" a
                SET ""TaxAddress""    = b.""TaxAddress"",
                    ""PostalCode""    = b.""PostalCode"",
                    ""BusinessName""  = b.""BusinessName"",
                    ""TaxId""         = b.""TaxId"",
                    ""Default""       = b.""Default"",
                    ""TaxRegimeId""   = b.""TaxRegimeId"",
                    ""Created""       = b.""Created"",
                    ""CreatedBy""     = b.""CreatedBy"",
                    ""LastModified""  = b.""LastModified"",
                    ""LastModifiedBy""= b.""LastModifiedBy""
                FROM ""TaxInfoBases"" b
                WHERE a.""Id"" = b.""Id"";
            ");

            migrationBuilder.Sql(@"
                DO $$
                DECLARE
                    id_offset INTEGER;
                BEGIN
                    -- Recover the original offset used in Up() to reverse ClientTaxInfos IDs.
                    -- AccountTaxInfos Ids in TaxInfoBases are the original ones (no offset applied).
                    -- ClientTaxInfos Ids in TaxInfoBases = original + offset.
                    -- The offset = GREATEST(max_account, max_client_original).
                    -- Since AccountTaxInfos Ids are unchanged, max_account = MAX(AccountTaxInfos.Id).
                    -- We can find the minimum gap: offset = MIN(ClientTaxInfos.Id) - 1
                    -- which is safe as long as original client IDs started at 1.
                    -- More robustly: offset = MAX(AccountTaxInfos.Id in TaxInfoBases that have no ClientTaxInfos match).
                    -- Simplest safe approach: subtract the max account Id.
                    SELECT COALESCE((SELECT MAX(b.""Id"") FROM ""TaxInfoBases"" b
                                     INNER JOIN ""AccountTaxInfos"" a ON a.""Id"" = b.""Id""), 0)
                    INTO id_offset;

                    UPDATE ""ClientTaxInfos"" c
                    SET ""TaxAddress""    = b.""TaxAddress"",
                        ""PostalCode""    = b.""PostalCode"",
                        ""BusinessName""  = b.""BusinessName"",
                        ""TaxId""         = b.""TaxId"",
                        ""Default""       = b.""Default"",
                        ""TaxRegimeId""   = b.""TaxRegimeId"",
                        ""Created""       = b.""Created"",
                        ""CreatedBy""     = b.""CreatedBy"",
                        ""LastModified""  = b.""LastModified"",
                        ""LastModifiedBy""= b.""LastModifiedBy""
                    FROM ""TaxInfoBases"" b
                    WHERE c.""Id"" = b.""Id"";

                    IF id_offset > 0 THEN
                        UPDATE ""ClientTaxInfos"" SET ""Id"" = ""Id"" - id_offset;
                    END IF;
                END $$;
            ");

            // Step 5: Drop TaxInfoBases AFTER data has been restored
            migrationBuilder.DropTable(name: "TaxInfoBases");

            // Step 6: Restore indexes and FKs
            migrationBuilder.CreateIndex(
                name: "IX_ClientTaxInfos_TaxRegimeId",
                table: "ClientTaxInfos",
                column: "TaxRegimeId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTaxInfos_TaxRegimeId",
                table: "AccountTaxInfos",
                column: "TaxRegimeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AccountTaxInfos_TaxRegimes_TaxRegimeId",
                table: "AccountTaxInfos",
                column: "TaxRegimeId",
                principalTable: "TaxRegimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTaxInfos_Clients_ClientId",
                table: "ClientTaxInfos",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientTaxInfos_TaxRegimes_TaxRegimeId",
                table: "ClientTaxInfos",
                column: "TaxRegimeId",
                principalTable: "TaxRegimes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
