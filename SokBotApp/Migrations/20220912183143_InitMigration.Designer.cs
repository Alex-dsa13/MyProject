// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SokBotApp.Models;

#nullable disable

namespace SokBotApp.Migrations
{
    [DbContext(typeof(sokuser_databaseContext))]
    [Migration("20220912183143_InitMigration")]
    partial class InitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SokBotApp.Models.SokGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("SokGroups");
                });

            modelBuilder.Entity("SokBotApp.Student", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Course")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Faculty")
                        .HasColumnType("int");

                    b.Property<string>("Fio")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<long>("IdVk")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ProfSouze")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
