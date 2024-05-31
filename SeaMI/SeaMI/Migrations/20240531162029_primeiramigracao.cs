using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SeaMI.Migrations
{
    /// <inheritdoc />
    public partial class primeiramigracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_GS_LOGIN",
                columns: table => new
                {
                    cdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    dsEmail = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    dsSenha = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    fgAtivo = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_LOGIN", x => x.cdLogin);
                });

            migrationBuilder.CreateTable(
                name: "T_GS_USUARIO",
                columns: table => new
                {
                    cdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cdLogin = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    nmUsuario = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    nrDocumento = table.Column<string>(type: "NVARCHAR2(15)", maxLength: 15, nullable: false),
                    nrTelefone = table.Column<string>(type: "NVARCHAR2(14)", maxLength: 14, nullable: false),
                    dsArea = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    dsNacionalidade = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    dtNascimento = table.Column<DateTime>(type: "DATE", nullable: false),
                    dtCadastro = table.Column<DateTime>(type: "DATE", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_GS_USUARIO", x => x.cdUsuario);
                    table.ForeignKey(
                        name: "FK_T_GS_USUARIO_T_GS_LOGIN_cdLogin",
                        column: x => x.cdLogin,
                        principalTable: "T_GS_LOGIN",
                        principalColumn: "cdLogin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_GS_USUARIO_cdLogin",
                table: "T_GS_USUARIO",
                column: "cdLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_GS_USUARIO");

            migrationBuilder.DropTable(
                name: "T_GS_LOGIN");
        }
    }
}
