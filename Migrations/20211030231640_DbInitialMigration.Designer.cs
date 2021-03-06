using LoginPage.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LoginPage.Migrations
{
    [DbContext(typeof(TableContext))]
    [Migration("20211030231640_DbInitialMigration")]
    partial class DbInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("LoginPage.Models.Login", b =>
                {
                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.Property<string>("adress")
                        .HasColumnType("text");

                    b.Property<string>("gsm")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .HasColumnType("text");

                    b.HasKey("username");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("LoginPage.Models.Table", b =>
                {
                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("adress")
                        .HasColumnType("text");

                    b.Property<string>("gsm")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("status")
                        .HasColumnType("text");

                    b.Property<string>("surname")
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("username");

                    b.ToTable("Tables");
                });
#pragma warning restore 612, 618
        }
    }
}
