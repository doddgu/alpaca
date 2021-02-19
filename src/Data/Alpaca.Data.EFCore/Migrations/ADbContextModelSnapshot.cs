﻿// <auto-generated />
using System;
using Alpaca.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Alpaca.Data.EFCore.Migrations
{
    [DbContext(typeof(ADbContext))]
    partial class ADbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Alpaca.Data.Entities.ConfigApp", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.Property<int>("VerifyMissingDays")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ConfigApp");
                });

            modelBuilder.Entity("Alpaca.Data.Entities.ConfigAppEnvironment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigAppID")
                        .HasColumnType("int");

                    b.Property<int>("ConfigEnvironmentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ConfigAppEnvironment");
                });

            modelBuilder.Entity("Alpaca.Data.Entities.ConfigDispatch", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("Enabled")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("JsonConfig")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ConfigDispatch");
                });

            modelBuilder.Entity("Alpaca.Data.Entities.ConfigEnvironment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("ConfigEnvironment");
                });

            modelBuilder.Entity("Alpaca.Data.Entities.ConfigItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigAppID")
                        .HasColumnType("int");

                    b.Property<int>("ConfigEnvironmentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Namespace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ConfigItem");
                });

            modelBuilder.Entity("Alpaca.Data.Entities.ConfigItemSniffer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ConfigAppID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Namespace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.Property<DateTime>("VerifyMissingTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("ConfigItemSniffer");
                });

            modelBuilder.Entity("Alpaca.Data.Entities.Permission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Permission");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Code = "100",
                            CreateTime = new DateTime(2021, 2, 20, 0, 16, 2, 814, DateTimeKind.Local).AddTicks(4703),
                            CreateUserID = 0,
                            IsDeleted = false,
                            Name = "Admin",
                            UpdateTime = new DateTime(2021, 2, 20, 0, 16, 2, 814, DateTimeKind.Local).AddTicks(5992),
                            UpdateUserID = 0
                        },
                        new
                        {
                            ID = 2,
                            Code = "100101",
                            CreateTime = new DateTime(2021, 2, 20, 0, 16, 2, 814, DateTimeKind.Local).AddTicks(7349),
                            CreateUserID = 0,
                            IsDeleted = false,
                            Name = "UserPermissionManagement",
                            UpdateTime = new DateTime(2021, 2, 20, 0, 16, 2, 814, DateTimeKind.Local).AddTicks(7357),
                            UpdateUserID = 0
                        },
                        new
                        {
                            ID = 3,
                            Code = "100102",
                            CreateTime = new DateTime(2021, 2, 20, 0, 16, 2, 814, DateTimeKind.Local).AddTicks(7365),
                            CreateUserID = 0,
                            IsDeleted = false,
                            Name = "UserManagemenet",
                            UpdateTime = new DateTime(2021, 2, 20, 0, 16, 2, 814, DateTimeKind.Local).AddTicks(7366),
                            UpdateUserID = 0
                        });
                });

            modelBuilder.Entity("Alpaca.Data.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("NickName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CreateTime = new DateTime(2021, 2, 20, 0, 16, 2, 817, DateTimeKind.Local).AddTicks(9999),
                            CreateUserID = 0,
                            IsDeleted = false,
                            Name = "admin",
                            NickName = "Admin",
                            Password = "DB69FC039DCBD2962CB4D28F5891AAE1",
                            UpdateTime = new DateTime(2021, 2, 20, 0, 16, 2, 818, DateTimeKind.Local).AddTicks(21),
                            UpdateUserID = 0
                        });
                });

            modelBuilder.Entity("Alpaca.Data.Entities.UserPermission", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<int>("CreateUserID")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("PermissionCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UpdateUserID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("UserPermission");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            AppID = 0,
                            CreateTime = new DateTime(2021, 2, 20, 0, 16, 2, 818, DateTimeKind.Local).AddTicks(7331),
                            CreateUserID = 0,
                            IsDeleted = false,
                            PermissionCode = "100",
                            UpdateTime = new DateTime(2021, 2, 20, 0, 16, 2, 818, DateTimeKind.Local).AddTicks(7341),
                            UpdateUserID = 0,
                            UserID = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
