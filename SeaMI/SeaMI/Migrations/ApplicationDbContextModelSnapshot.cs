﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using SeaMI.Data;

#nullable disable

namespace SeaMI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SeaMI.Models.AmostraAgua", b =>
                {
                    b.Property<int>("cdAmostra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdAmostra"));

                    b.Property<int>("cdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("dsConcentracaoPlastico")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("dsNutrientes")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("dsOxigenioDissolvido")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("dsPH")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("NVARCHAR2(10)");

                    b.Property<string>("dsPoluentesQuimicos")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("dsTemperatura")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("dsTurbidez")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<DateTime>("dtColeta")
                        .HasColumnType("DATE");

                    b.HasKey("cdAmostra");

                    b.HasIndex("cdUsuario");

                    b.ToTable("TB_GS_AMOSTRA_AGUA", (string)null);
                });

            modelBuilder.Entity("SeaMI.Models.Login", b =>
                {
                    b.Property<int>("cdLogin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdLogin"));

                    b.Property<int>("cdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("dsEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<string>("dsSenha")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("cdLogin");

                    b.HasIndex("cdUsuario");

                    b.ToTable("TB_GS_LOGIN", (string)null);
                });

            modelBuilder.Entity("SeaMI.Models.Relatorio", b =>
                {
                    b.Property<int>("cdRelatorio")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdRelatorio"));

                    b.Property<int>("cdUsuario")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("dsRelatorio")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.Property<DateTime>("dtRelatorio")
                        .HasColumnType("DATE");

                    b.Property<string>("nmRelatorio")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.HasKey("cdRelatorio");

                    b.HasIndex("cdUsuario");

                    b.ToTable("TB_GS_RELATORIO", (string)null);
                });

            modelBuilder.Entity("SeaMI.Models.RelatorioAmostra", b =>
                {
                    b.Property<int>("cdRelatorioAmostra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdRelatorioAmostra"));

                    b.Property<int>("cdAmostra")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("cdRelatorio")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("dsRelatorioAmostra")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)");

                    b.HasKey("cdRelatorioAmostra");

                    b.HasIndex("cdAmostra");

                    b.HasIndex("cdRelatorio");

                    b.ToTable("TB_GS_RELATORIO_AMOSTRA", (string)null);
                });

            modelBuilder.Entity("SeaMI.Models.Usuario", b =>
                {
                    b.Property<int>("cdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cdUsuario"));

                    b.Property<string>("dsNacionalidade")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR2(50)");

                    b.Property<DateTime>("dtCadastro")
                        .HasColumnType("DATE");

                    b.Property<DateTime>("dtNascimento")
                        .HasColumnType("DATE");

                    b.Property<string>("nmUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)");

                    b.Property<string>("nrCpf")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("nrRG")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.Property<string>("nrTelefone")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("NVARCHAR2(15)");

                    b.HasKey("cdUsuario");

                    b.ToTable("TB_GS_USUARIO", (string)null);
                });

            modelBuilder.Entity("SeaMI.Models.AmostraAgua", b =>
                {
                    b.HasOne("SeaMI.Models.Usuario", "Usuario")
                        .WithMany("AmostrasAgua")
                        .HasForeignKey("cdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SeaMI.Models.Login", b =>
                {
                    b.HasOne("SeaMI.Models.Usuario", "Usuario")
                        .WithMany("Logins")
                        .HasForeignKey("cdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SeaMI.Models.Relatorio", b =>
                {
                    b.HasOne("SeaMI.Models.Usuario", "Usuario")
                        .WithMany("Relatorios")
                        .HasForeignKey("cdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SeaMI.Models.RelatorioAmostra", b =>
                {
                    b.HasOne("SeaMI.Models.AmostraAgua", "AmostraAgua")
                        .WithMany("RelatoriosAmostra")
                        .HasForeignKey("cdAmostra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SeaMI.Models.Relatorio", "Relatorio")
                        .WithMany("RelatoriosAmostra")
                        .HasForeignKey("cdRelatorio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AmostraAgua");

                    b.Navigation("Relatorio");
                });

            modelBuilder.Entity("SeaMI.Models.AmostraAgua", b =>
                {
                    b.Navigation("RelatoriosAmostra");
                });

            modelBuilder.Entity("SeaMI.Models.Relatorio", b =>
                {
                    b.Navigation("RelatoriosAmostra");
                });

            modelBuilder.Entity("SeaMI.Models.Usuario", b =>
                {
                    b.Navigation("AmostrasAgua");

                    b.Navigation("Logins");

                    b.Navigation("Relatorios");
                });
#pragma warning restore 612, 618
        }
    }
}
