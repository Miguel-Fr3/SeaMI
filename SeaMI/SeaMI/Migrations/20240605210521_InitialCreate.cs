using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaMI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_GS_USUARIO",
                columns: table => new
                {
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nmUsuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    nrRG = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    nrCpf = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsNacionalidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    nrTelefone = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dtNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GS_USUARIO", x => x.cdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "TB_GS_AMOSTRA_AGUA",
                columns: table => new
                {
                    cdAmostra = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dtColeta = table.Column<DateTime>(type: "DATE", nullable: false),
                    dsPH = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    dsPoluentesQuimicos = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsNutrientes = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsConcentracaoPlastico = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsOxigenioDissolvido = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsTemperatura = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    dsTurbidez = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GS_AMOSTRA_AGUA", x => x.cdAmostra);
                    table.ForeignKey(
                        name: "FK_TB_GS_AMOSTRA_AGUA_TB_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "TB_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_GS_LOGIN",
                columns: table => new
                {
                    cdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dsEmail = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    dsSenha = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GS_LOGIN", x => x.cdLogin);
                    table.ForeignKey(
                        name: "FK_TB_GS_LOGIN_TB_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "TB_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_GS_RELATORIO",
                columns: table => new
                {
                    cdRelatorio = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    nmRelatorio = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    dsRelatorio = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    dtRelatorio = table.Column<DateTime>(type: "DATE", nullable: false),
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_GS_RELATORIO", x => x.cdRelatorio);
                    table.ForeignKey(
                        name: "FK_TB_GS_RELATORIO_TB_GS_USUARIO_cdUsuario",
                        column: x => x.cdUsuario,
                        principalTable: "TB_GS_USUARIO",
                        principalColumn: "cdUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_GS_AMOSTRA_AGUA_cdUsuario",
                table: "TB_GS_AMOSTRA_AGUA",
                column: "cdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_GS_LOGIN_cdUsuario",
                table: "TB_GS_LOGIN",
                column: "cdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_TB_GS_RELATORIO_cdUsuario",
                table: "TB_GS_RELATORIO",
                column: "cdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_GS_AMOSTRA_AGUA");

            migrationBuilder.DropTable(
                name: "TB_GS_LOGIN");

            migrationBuilder.DropTable(
                name: "TB_GS_RELATORIO");

            migrationBuilder.DropTable(
                name: "TB_GS_USUARIO");
        }
    }
}
