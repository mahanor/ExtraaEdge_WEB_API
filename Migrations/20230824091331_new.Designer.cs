﻿// <auto-generated />
using System;
using ExtraaEdge_WEB_API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExtraaEdgeWEBAPI.Migrations
{
    [DbContext(typeof(CollectionContext))]
    [Migration("20230824091331_new")]
    partial class @new
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Brand", b =>
                {
                    b.Property<int>("BrandID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrandID"));

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrandID");

                    b.ToTable("brands");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Customer", b =>
                {
                    b.Property<int>("CustId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustId"));

                    b.Property<string>("CustAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustPhoneNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustId");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.LoginModel", b =>
                {
                    b.Property<string>("StoreOwnerName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StoreOwnerName");

                    b.ToTable("login");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Mobile", b =>
                {
                    b.Property<int>("MobileID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MobileID"));

                    b.Property<int>("BrandID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("MobileID");

                    b.HasIndex("BrandID");

                    b.ToTable("mobiles");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Sale", b =>
                {
                    b.Property<int>("SaleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleID"));

                    b.Property<int>("DiscountApplied")
                        .HasColumnType("int");

                    b.Property<int>("MobileID")
                        .HasColumnType("int");

                    b.Property<int>("MobileIdNumber")
                        .HasColumnType("int");

                    b.Property<int>("SaleAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SaleID");

                    b.HasIndex("MobileID");

                    b.ToTable("sales");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Mobile", b =>
                {
                    b.HasOne("ExtraaEdge_WEB_API.Model.Brand", "Brand")
                        .WithMany("Mobiles")
                        .HasForeignKey("BrandID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Sale", b =>
                {
                    b.HasOne("ExtraaEdge_WEB_API.Model.Mobile", "Mobile")
                        .WithMany("Sales")
                        .HasForeignKey("MobileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mobile");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Brand", b =>
                {
                    b.Navigation("Mobiles");
                });

            modelBuilder.Entity("ExtraaEdge_WEB_API.Model.Mobile", b =>
                {
                    b.Navigation("Sales");
                });
#pragma warning restore 612, 618
        }
    }
}
