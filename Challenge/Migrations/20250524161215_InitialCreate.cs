using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Challenge.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeFilial = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Endereco = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Cidade = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Estado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CapacidadeTotal = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    StatusOperacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Zona",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeZona = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoFuncional = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    QtdVagas = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PatioId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zona", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zona_Patio_PatioId",
                        column: x => x.PatioId,
                        principalTable: "Patio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Placa = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Chassi = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Modelo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Marca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RfidTag = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    StatusMoto = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ZonaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PosicaoZona = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moto_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensor_RFID",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ZonaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoSensor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Ativo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor_RFID", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sensor_RFID_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Historico_Movimentacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    MotoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ZonaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataMovimentacao = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ImagemCapturada = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoEvento = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico_Movimentacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Historico_Movimentacao_Moto_MotoId",
                        column: x => x.MotoId,
                        principalTable: "Moto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_Movimentacao_Sensor_RFID_SensorId",
                        column: x => x.SensorId,
                        principalTable: "Sensor_RFID",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Historico_Movimentacao_Zona_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "Zona",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Movimentacao_MotoId",
                table: "Historico_Movimentacao",
                column: "MotoId");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Movimentacao_SensorId",
                table: "Historico_Movimentacao",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_Historico_Movimentacao_ZonaId",
                table: "Historico_Movimentacao",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Moto_ZonaId",
                table: "Moto",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_RFID_ZonaId",
                table: "Sensor_RFID",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_Zona_PatioId",
                table: "Zona",
                column: "PatioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historico_Movimentacao");

            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "Sensor_RFID");

            migrationBuilder.DropTable(
                name: "Zona");

            migrationBuilder.DropTable(
                name: "Patio");
        }
    }
}
