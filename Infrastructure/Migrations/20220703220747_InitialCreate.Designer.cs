﻿// <auto-generated />
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220703220747_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DestrezaItem", b =>
                {
                    b.Property<int>("DestrezasId")
                        .HasColumnType("int");

                    b.Property<int>("ItemsId")
                        .HasColumnType("int");

                    b.HasKey("DestrezasId", "ItemsId");

                    b.HasIndex("ItemsId");

                    b.ToTable("DestrezaItem");
                });

            modelBuilder.Entity("Domain.Entities.Destreza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Destrezas");
                });

            modelBuilder.Entity("Domain.Entities.DestrezaGuerrero", b =>
                {
                    b.Property<int>("DestrezaId")
                        .HasColumnType("int");

                    b.Property<int>("GuerreroId")
                        .HasColumnType("int");

                    b.Property<int>("Grado")
                        .HasColumnType("int");

                    b.Property<int>("NivelId")
                        .HasColumnType("int");

                    b.HasKey("DestrezaId", "GuerreroId");

                    b.HasIndex("GuerreroId");

                    b.HasIndex("NivelId");

                    b.ToTable("DestrezaGuerreros");
                });

            modelBuilder.Entity("Domain.Entities.Guerrero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Guerreros");
                });

            modelBuilder.Entity("Domain.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CostoDiamante")
                        .HasColumnType("int");

                    b.Property<int>("CostoOro")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Domain.Entities.Nivel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Niveles");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Diamantes")
                        .HasColumnType("int");

                    b.Property<int>("Oro")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("DestrezaItem", b =>
                {
                    b.HasOne("Domain.Entities.Destreza", null)
                        .WithMany()
                        .HasForeignKey("DestrezasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Item", null)
                        .WithMany()
                        .HasForeignKey("ItemsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.DestrezaGuerrero", b =>
                {
                    b.HasOne("Domain.Entities.Destreza", "Destreza")
                        .WithMany()
                        .HasForeignKey("DestrezaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Guerrero", "Guerrero")
                        .WithMany()
                        .HasForeignKey("GuerreroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Nivel", "Nivel")
                        .WithMany()
                        .HasForeignKey("NivelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Destreza");

                    b.Navigation("Guerrero");

                    b.Navigation("Nivel");
                });

            modelBuilder.Entity("Domain.Entities.Guerrero", b =>
                {
                    b.HasOne("Domain.Entities.Usuario", "Usuario")
                        .WithMany("Guerreros")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entities.Usuario", b =>
                {
                    b.Navigation("Guerreros");
                });
#pragma warning restore 612, 618
        }
    }
}
