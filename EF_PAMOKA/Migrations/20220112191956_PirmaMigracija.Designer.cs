// <auto-generated />
using System;
using EF_PAMOKA.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace EF_PAMOKA.Migrations
{
    [DbContext(typeof(PavyzdinisDbContext))]
    [Migration("20220112191956_PirmaMigracija")]
    partial class PirmaMigracija
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("EF_PAMOKA.Models.Automobilis", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Marke")
                        .HasColumnType("text");

                    b.Property<string>("Modelis")
                        .HasColumnType("text");

                    b.Property<int?>("SavininkoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Automobiliai");
                });

            modelBuilder.Entity("EF_PAMOKA.Models.Daiktas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Pavadinimas")
                        .HasColumnType("text");

                    b.Property<int?>("SavininkoId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Daiktai");
                });

            modelBuilder.Entity("EF_PAMOKA.Models.Savininkas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Vardas")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Savininkai");
                });
#pragma warning restore 612, 618
        }
    }
}
