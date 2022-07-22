﻿// <auto-generated />
using System;
using Helpdesk.RepositoryEf.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Helpdesk.RepositoryEf.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220721212756_FormsAgency")]
    partial class FormsAgency
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Helpdesk.Core.Entities.AgencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("AgencyTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Log")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Phone")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Settlement")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("State")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("TownHall")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)");

                    b.HasKey("Id");

                    b.ToTable("Agency");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Domicilio conocido",
                            AgencyTypeId = 1,
                            Code = "01",
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8985),
                            IsActive = true,
                            Log = "",
                            Name = "Principal",
                            Notes = "",
                            Phone = "",
                            ProjectId = 1,
                            Settlement = "",
                            State = "",
                            TownHall = "",
                            UserId = 1,
                            ZipCode = ""
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.AgencyTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("AgencyType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8953),
                            IsActive = true,
                            Name = "Corporativo"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8957),
                            IsActive = true,
                            Name = "Matriz"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8960),
                            IsActive = true,
                            Name = "Sucursal"
                        },
                        new
                        {
                            Id = 4,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8964),
                            IsActive = true,
                            Name = "Punto de venta"
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.DeviceEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeviceStateId")
                        .HasColumnType("int");

                    b.Property<int?>("FormAgencyEntityId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("SerialNumber")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormAgencyEntityId");

                    b.ToTable("Device");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.DeviceStateEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("DeviceState");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9062),
                            IsActive = true,
                            Name = "En almacen"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9066),
                            IsActive = true,
                            Name = "Asignado"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9069),
                            IsActive = true,
                            Name = "Merma"
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.FormAgencyDevicesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DeviceId")
                        .HasColumnType("int");

                    b.Property<int>("FormAgencyId")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId");

                    b.HasIndex("FormAgencyId");

                    b.ToTable("FormAgencyDevices");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.FormAgencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("FormAgency");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.PersonEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AgencyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AgencyId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AgencyId = 1,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9003),
                            IsActive = true,
                            LastName = "Admin",
                            Name = "Admin",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.ProjectEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)");

                    b.Property<string>("Reason")
                        .HasColumnType("longtext");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(8828),
                            IsActive = true,
                            Name = "Proyecto inicial",
                            Notes = "Proyecto inicial",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9019),
                            IsActive = true,
                            Name = "Nivel 1"
                        },
                        new
                        {
                            Id = 2,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9023),
                            IsActive = true,
                            Name = "Nivel 2"
                        },
                        new
                        {
                            Id = 3,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9026),
                            IsActive = true,
                            Name = "Nivel 3"
                        },
                        new
                        {
                            Id = 4,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9029),
                            IsActive = true,
                            Name = "Nivel 4"
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateRegistration")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Password")
                        .HasMaxLength(12)
                        .HasColumnType("varchar(12)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateRegistration = new DateTime(2022, 7, 21, 16, 27, 55, 506, DateTimeKind.Local).AddTicks(9044),
                            Email = "administrador",
                            IsActive = true,
                            Password = "123456",
                            PersonId = 1,
                            RoleId = 1,
                            UserId = 0
                        });
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.DeviceEntity", b =>
                {
                    b.HasOne("Helpdesk.Core.Entities.FormAgencyEntity", null)
                        .WithMany("ListDevices")
                        .HasForeignKey("FormAgencyEntityId");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.FormAgencyDevicesEntity", b =>
                {
                    b.HasOne("Helpdesk.Core.Entities.DeviceEntity", "Device")
                        .WithMany()
                        .HasForeignKey("DeviceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Helpdesk.Core.Entities.FormAgencyEntity", "FormAgency")
                        .WithMany()
                        .HasForeignKey("FormAgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Device");

                    b.Navigation("FormAgency");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.FormAgencyEntity", b =>
                {
                    b.HasOne("Helpdesk.Core.Entities.AgencyEntity", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.PersonEntity", b =>
                {
                    b.HasOne("Helpdesk.Core.Entities.AgencyEntity", "Agency")
                        .WithMany()
                        .HasForeignKey("AgencyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agency");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.UserEntity", b =>
                {
                    b.HasOne("Helpdesk.Core.Entities.PersonEntity", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Helpdesk.Core.Entities.FormAgencyEntity", b =>
                {
                    b.Navigation("ListDevices");
                });
#pragma warning restore 612, 618
        }
    }
}