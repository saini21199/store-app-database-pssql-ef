﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SamuraiApp.Data;

namespace SamuraiApp.Data.Migrations
{
    [DbContext(typeof(DepartmentContext))]
    [Migration("20210520110430_v3")]
    partial class v3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("SamuraiApp.Domain.Address", b =>
                {
                    b.Property<int>("address_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("addressLine_1")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("city")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<long>("pincode")
                        .HasColumnType("bigint")
                        .HasMaxLength(10);

                    b.Property<string>("state")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.HasKey("address_id");

                    b.ToTable("address");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Category", b =>
                {
                    b.Property<int>("category_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("cat_code")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("cat_name")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.HasKey("category_id");

                    b.ToTable("category");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("category_id")
                        .HasColumnType("integer");

                    b.Property<int>("costPrice")
                        .HasColumnType("integer");

                    b.Property<string>("manufacturer")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<int>("sellingPrice")
                        .HasColumnType("integer");

                    b.HasKey("product_id");

                    b.HasIndex("category_id");

                    b.ToTable("product");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Role", b =>
                {
                    b.Property<int>("role_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.HasKey("role_id");

                    b.ToTable("role");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Staff", b =>
                {
                    b.Property<int>("staff_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Staff_name")
                        .HasColumnType("character varying(64)")
                        .HasMaxLength(64);

                    b.Property<int>("address_id")
                        .HasColumnType("integer");

                    b.Property<string>("phone_no")
                        .IsRequired()
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<int>("role_id")
                        .HasColumnType("integer");

                    b.HasKey("staff_id");

                    b.HasIndex("address_id");

                    b.HasIndex("role_id");

                    b.ToTable("staff");
                });

            modelBuilder.Entity("SamuraiApp.Domain.Product", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Category", "categories")
                        .WithMany("Product")
                        .HasForeignKey("category_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SamuraiApp.Domain.Staff", b =>
                {
                    b.HasOne("SamuraiApp.Domain.Address", "addresses")
                        .WithMany("Staff")
                        .HasForeignKey("address_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SamuraiApp.Domain.Role", "roles")
                        .WithMany("Staff")
                        .HasForeignKey("role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
