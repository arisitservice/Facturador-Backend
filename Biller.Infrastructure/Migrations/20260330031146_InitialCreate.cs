using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Biller.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Emisores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RegimenFiscal = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Rfc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emisores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaveSat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MotivosCancelacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaveSat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotivosCancelacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaveSat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegimenesFiscales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaveSat = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegimenesFiscales", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaveSat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UsosCfdi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClaveSat = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsosCfdi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Receptores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DomicilioFiscal = table.Column<string>(type: "text", nullable: false),
                    CodigoPostal = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    RazonSocial = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Rfc = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IdRegimenFiscal = table.Column<int>(type: "integer", nullable: false),
                    IdUsoCfdi = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receptores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receptores_RegimenesFiscales_IdRegimenFiscal",
                        column: x => x.IdRegimenFiscal,
                        principalTable: "RegimenesFiscales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Receptores_UsosCfdi_IdUsoCfdi",
                        column: x => x.IdUsoCfdi,
                        principalTable: "UsosCfdi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cfdis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UUID = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    TipoComprobante = table.Column<int>(type: "integer", nullable: false),
                    IdFacturaRelacion = table.Column<int>(type: "integer", nullable: true),
                    IdReceptor = table.Column<int>(type: "integer", nullable: false),
                    IdEmisor = table.Column<int>(type: "integer", nullable: false),
                    IdUsoCfdi = table.Column<int>(type: "integer", nullable: false),
                    IdMoneda = table.Column<int>(type: "integer", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    IdMedioPago = table.Column<int>(type: "integer", nullable: false),
                    MetodoPago = table.Column<int>(type: "integer", nullable: false),
                    ObjetoImpuesto = table.Column<int>(type: "integer", nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false),
                    EstatusTimbrado = table.Column<int>(type: "integer", nullable: false),
                    EstatusPago = table.Column<int>(type: "integer", nullable: false),
                    Notas = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cfdis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cfdis_Emisores_IdEmisor",
                        column: x => x.IdEmisor,
                        principalTable: "Emisores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cfdis_Receptores_IdReceptor",
                        column: x => x.IdReceptor,
                        principalTable: "Receptores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CfdiComplementosPago",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCfdi = table.Column<int>(type: "integer", nullable: false),
                    IdFacturaRelacion = table.Column<int>(type: "integer", nullable: false),
                    IdFormaPago = table.Column<int>(type: "integer", nullable: false),
                    IdMoneda = table.Column<int>(type: "integer", nullable: false),
                    TipoCambio = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    FechaPago = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    NumOperacion = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ObjetoImpuesto = table.Column<int>(type: "integer", nullable: false),
                    Serie = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    Equivalencia = table.Column<decimal>(type: "numeric(18,6)", precision: 18, scale: 6, nullable: false),
                    NumParcialidad = table.Column<int>(type: "integer", nullable: false),
                    ImporteSaldoAnterior = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    ImportePagado = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    ImportePagadoInsoluto = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CfdiComplementosPago", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfdiComplementosPago_Cfdis_IdCfdi",
                        column: x => x.IdCfdi,
                        principalTable: "Cfdis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CfdiConceptos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdCfdi = table.Column<int>(type: "integer", nullable: false),
                    Descripcion = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    IdServicio = table.Column<int>(type: "integer", nullable: false),
                    IdUnidadMedida = table.Column<int>(type: "integer", nullable: false),
                    Cantidad = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    Importe = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    TrasladoIva = table.Column<decimal>(type: "numeric(18,4)", precision: 18, scale: 4, nullable: false),
                    Estatus = table.Column<int>(type: "integer", nullable: false),
                    CreatedBy = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CfdiConceptos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CfdiConceptos_Cfdis_IdCfdi",
                        column: x => x.IdCfdi,
                        principalTable: "Cfdis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CfdiComplementosPago_IdCfdi",
                table: "CfdiComplementosPago",
                column: "IdCfdi");

            migrationBuilder.CreateIndex(
                name: "IX_CfdiConceptos_IdCfdi",
                table: "CfdiConceptos",
                column: "IdCfdi");

            migrationBuilder.CreateIndex(
                name: "IX_Cfdis_IdEmisor",
                table: "Cfdis",
                column: "IdEmisor");

            migrationBuilder.CreateIndex(
                name: "IX_Cfdis_IdReceptor",
                table: "Cfdis",
                column: "IdReceptor");

            migrationBuilder.CreateIndex(
                name: "IX_Receptores_IdRegimenFiscal",
                table: "Receptores",
                column: "IdRegimenFiscal");

            migrationBuilder.CreateIndex(
                name: "IX_Receptores_IdUsoCfdi",
                table: "Receptores",
                column: "IdUsoCfdi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CfdiComplementosPago");

            migrationBuilder.DropTable(
                name: "CfdiConceptos");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "MotivosCancelacion");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropTable(
                name: "Cfdis");

            migrationBuilder.DropTable(
                name: "Emisores");

            migrationBuilder.DropTable(
                name: "Receptores");

            migrationBuilder.DropTable(
                name: "RegimenesFiscales");

            migrationBuilder.DropTable(
                name: "UsosCfdi");
        }
    }
}
