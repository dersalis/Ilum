﻿// <auto-generated />
using System;
using Ilum.Api.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ilum.Api.Migrations
{
    [DbContext(typeof(IlumContext))]
    partial class IlumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Ilum.Api.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("CreateByUserId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("ModifiedByUserId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId1");

                    b.HasIndex("ModifiedByUserId1");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Ilum.Api.Models.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PlannedFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("ModifiedByUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Ilum.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CreateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentPassword")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId1")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId2")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastPassword")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ModifiedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("Id"));

                    b.HasIndex("CreateByUserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DepartmentId1");

                    b.HasIndex("DepartmentId2")
                        .IsUnique()
                        .HasFilter("[DepartmentId2] IS NOT NULL");

                    b.HasIndex("ModifiedByUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Ilum.Api.Models.Department", b =>
                {
                    b.HasOne("Ilum.Api.Models.User", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId1");

                    b.HasOne("Ilum.Api.Models.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId1");

                    b.Navigation("CreateByUser");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("Ilum.Api.Models.Task", b =>
                {
                    b.HasOne("Ilum.Api.Models.User", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId");

                    b.HasOne("Ilum.Api.Models.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId");

                    b.HasOne("Ilum.Api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreateByUser");

                    b.Navigation("ModifiedByUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ilum.Api.Models.User", b =>
                {
                    b.HasOne("Ilum.Api.Models.User", "CreateByUser")
                        .WithMany()
                        .HasForeignKey("CreateByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Ilum.Api.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Ilum.Api.Models.Department", null)
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId1");

                    b.HasOne("Ilum.Api.Models.Department", null)
                        .WithOne("Leader")
                        .HasForeignKey("Ilum.Api.Models.User", "DepartmentId2");

                    b.HasOne("Ilum.Api.Models.User", "ModifiedByUser")
                        .WithMany()
                        .HasForeignKey("ModifiedByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("CreateByUser");

                    b.Navigation("Department");

                    b.Navigation("ModifiedByUser");
                });

            modelBuilder.Entity("Ilum.Api.Models.Department", b =>
                {
                    b.Navigation("Leader")
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
