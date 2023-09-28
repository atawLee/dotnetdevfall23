﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using mesWeb.Entity;

#nullable disable

namespace mesWeb.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230928062546_v092802")]
    partial class v092802
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("mesWeb.Database.Entity.Manufacture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<decimal>("FaultQty")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("Summary")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("WorkEndTime")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("WorkOrderId")
                        .HasColumnType("int");

                    b.Property<decimal>("WorkQty")
                        .HasColumnType("decimal(65,30)");

                    b.Property<DateTime>("WorkStartTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Worker")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("WorkOrderId");

                    b.ToTable("Manufactures");
                });

            modelBuilder.Entity("mesWeb.Database.Entity.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OrderUser")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("TargetQty")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("Id");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("mesWeb.Database.Entity.Manufacture", b =>
                {
                    b.HasOne("mesWeb.Database.Entity.WorkOrder", "WorkOrder")
                        .WithMany("Manufactures")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("mesWeb.Database.Entity.WorkOrder", b =>
                {
                    b.Navigation("Manufactures");
                });
#pragma warning restore 612, 618
        }
    }
}
