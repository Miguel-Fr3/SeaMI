using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaMI.Migrations
{
    /// <inheritdoc />
    public partial class secmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_GS_AMOSTRA_AGUA",
                columns: table => new
                {
                    cdAmostra = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dtColeta = table.Column<DateTime>(type: "DATE", nullable: false),
                    dsPH = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsPoluentesQuimicos = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsNutrientes = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsConcentracaoPlastico = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsOxigenioDissolvido = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsTemperatura = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsTurbidez = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_AMOSTRA_AGUA", x => x.cdAmostra);
                });

            migrationBuilder.CreateTable(
                name: "T_GS_APROVACAO_RELATORIO",
                columns: table => new
                {
                    cdAprovacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    fgAprovado = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dsComentario = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    dtAprovacao = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_APROVACAO_RELATORIO", x => x.cdAprovacao);
                    table.ForeignKey(
                        name: "FK_T_GS_APROVACAO_RELATORIO_T_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "T_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_GS_SENSORES",
                columns: table => new
                {
                    cdSensor = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nmTecnologia = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    dsSensor = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    dtImplementacao = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_SENSORES", x => x.cdSensor);
                    table.ForeignKey(
                        name: "FK_T_GS_SENSORES_T_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "T_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_GS_AMOSTRA_USUARIO",
                columns: table => new
                {
                    cdAmostraUser = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    cdAmostra = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dsAmostra = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    dtAmostra = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_AMOSTRA_USUARIO", x => x.cdAmostraUser);
                    table.ForeignKey(
                        name: "FK_T_GS_AMOSTRA_USUARIO_T_GS_AMOSTRA_AGUA_cdAmostra",
                        column: x => x.cdAmostra,
                        principalTable: "T_GS_AMOSTRA_AGUA",
                        principalColumn: "cdAmostra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_GS_AMOSTRA_USUARIO_T_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "T_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_GS_RELATORIO_AGUA",
                columns: table => new
                {
                    cdRelatorio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    cdAprovacao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dtRelatorio = table.Column<DateTime>(type: "DATE", nullable: false),
                    dsRelatorio = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_RELATORIO_AGUA", x => x.cdRelatorio);
                    table.ForeignKey(
                        name: "FK_T_GS_RELATORIO_AGUA_T_GS_APROVACAO_RELATORIO_cdAprovacao",
                        column: x => x.cdAprovacao,
                        principalTable: "T_GS_APROVACAO_RELATORIO",
                        principalColumn: "cdAprovacao",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_GS_RELATORIO_AGUA_T_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "T_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_GS_MONITORAMENTO_AGUA",
                columns: table => new
                {
                    cdMonitoramentoAgua = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cdSensor = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    cdAmostra = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    dsMonitoramento = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_MONITORAMENTO_AGUA", x => x.cdMonitoramentoAgua);
                    table.ForeignKey(
                        name: "FK_T_GS_MONITORAMENTO_AGUA_T_GS_AMOSTRA_AGUA_cdAmostra",
                        column: x => x.cdAmostra,
                        principalTable: "T_GS_AMOSTRA_AGUA",
                        principalColumn: "cdAmostra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_T_GS_MONITORAMENTO_AGUA_T_GS_SENSORES_cdSensor",
                        column: x => x.cdSensor,
                        principalTable: "T_GS_SENSORES",
                        principalColumn: "cdSensor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_AMOSTRA_USUARIO_cdAmostra",
                table: "T_GS_AMOSTRA_USUARIO",
                column: "cdAmostra");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_AMOSTRA_USUARIO_cdUsuario",
                table: "T_GS_AMOSTRA_USUARIO",
                column: "cdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_APROVACAO_RELATORIO_cdUsuario",
                table: "T_GS_APROVACAO_RELATORIO",
                column: "cdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_MONITORAMENTO_AGUA_cdAmostra",
                table: "T_GS_MONITORAMENTO_AGUA",
                column: "cdAmostra");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_MONITORAMENTO_AGUA_cdSensor",
                table: "T_GS_MONITORAMENTO_AGUA",
                column: "cdSensor");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_RELATORIO_AGUA_cdAprovacao",
                table: "T_GS_RELATORIO_AGUA",
                column: "cdAprovacao");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_RELATORIO_AGUA_cdUsuario",
                table: "T_GS_RELATORIO_AGUA",
                column: "cdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_SENSORES_cdUsuario",
                table: "T_GS_SENSORES",
                column: "cdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_GS_AMOSTRA_USUARIO");

            migrationBuilder.DropTable(
                name: "T_GS_MONITORAMENTO_AGUA");

            migrationBuilder.DropTable(
                name: "T_GS_RELATORIO_AGUA");

            migrationBuilder.DropTable(
                name: "T_GS_AMOSTRA_AGUA");

            migrationBuilder.DropTable(
                name: "T_GS_SENSORES");

            migrationBuilder.DropTable(
                name: "T_GS_APROVACAO_RELATORIO");
        }
    }
}
