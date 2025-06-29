﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UniCMMS.Infrastructure.Persistence;

#nullable disable

namespace UniCMMS.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250529104134_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("UniCMMS.Domain.Entities.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.WorkOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("WorkOrders");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.WorkOrderAssignee", b =>
                {
                    b.Property<int>("WorkOrderId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("WorkOrderId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("WorkOrderAssignees");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.WorkOrder", b =>
                {
                    b.HasOne("UniCMMS.Domain.Entities.Status", "Status")
                        .WithMany("WorkOrders")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.WorkOrderAssignee", b =>
                {
                    b.HasOne("UniCMMS.Domain.Entities.User", "User")
                        .WithMany("WorkOrderAssignees")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UniCMMS.Domain.Entities.WorkOrder", "WorkOrder")
                        .WithMany("WorkOrderAssignees")
                        .HasForeignKey("WorkOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("WorkOrder");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.Status", b =>
                {
                    b.Navigation("WorkOrders");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.User", b =>
                {
                    b.Navigation("WorkOrderAssignees");
                });

            modelBuilder.Entity("UniCMMS.Domain.Entities.WorkOrder", b =>
                {
                    b.Navigation("WorkOrderAssignees");
                });
#pragma warning restore 612, 618
        }
    }
}
