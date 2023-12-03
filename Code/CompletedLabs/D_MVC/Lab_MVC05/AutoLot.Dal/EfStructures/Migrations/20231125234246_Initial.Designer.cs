﻿// <auto-generated />
using System;
using System.Collections.Generic;
using AutoLot.Dal.EfStructures;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoLot.Dal.EfStructures.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231125234246_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AutoLot.Models.Entities.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateBuilt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("Display")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("nvarchar(max)")
                        .HasComputedColumnSql("[PetName] + ' (' + [Color] + ')'", true);

                    b.Property<bool>("IsDrivable")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("MakeId")
                        .HasColumnType("int");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "MakeId" }, "IX_Inventory_MakeId");

                    b.ToTable("Inventory", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("InventoryAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.CarDriver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("InventoryId");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("DriverId");

                    b.HasIndex("CarId", "DriverId")
                        .IsUnique();

                    b.ToTable("InventoryToDrivers", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("InventoryToDriversAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.CreditRisk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.ComplexProperty<Dictionary<string, object>>("PersonInformation", "AutoLot.Models.Entities.CreditRisk.PersonInformation#Person", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("FullName")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FullName")
                                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");
                        });

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CustomerId" }, "IX_CreditRisks_CustomerId");

                    b.ToTable("CreditRisks", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("CreditRiskAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.ComplexProperty<Dictionary<string, object>>("PersonInformation", "AutoLot.Models.Entities.Customer.PersonInformation#Person", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("FullName")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FullName")
                                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");
                        });

                    b.HasKey("Id");

                    b.ToTable("Customers", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("CustomerAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.ComplexProperty<Dictionary<string, object>>("PersonInformation", "AutoLot.Models.Entities.Driver.PersonInformation#Person", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("FullName")
                                .ValueGeneratedOnAddOrUpdate()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FullName")
                                .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasMaxLength(50)
                                .HasColumnType("nvarchar(50)")
                                .HasColumnName("LastName");
                        });

                    b.HasKey("Id");

                    b.ToTable("Drivers", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("DriverAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Make", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.ToTable("Makes", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("MakesAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId", "CarId")
                        .IsUnique();

                    b.HasIndex(new[] { "CarId" }, "IX_Orders_CarId");

                    b.HasIndex(new[] { "CustomerId", "CarId" }, "IX_Orders_CustomerId_CarId")
                        .IsUnique();

                    b.ToTable("Orders", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("OrdersAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Radio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int")
                        .HasColumnName("InventoryId");

                    b.Property<bool>("HasSubWoofers")
                        .HasColumnType("bit");

                    b.Property<bool>("HasTweeters")
                        .HasColumnType("bit");

                    b.Property<string>("RadioId")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("TimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<DateTime>("ValidFrom")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidFrom");

                    b.Property<DateTime>("ValidTo")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasColumnName("ValidTo");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CarId" }, "IX_Radios_CarId")
                        .IsUnique();

                    b.ToTable("Radios", "dbo");

                    b.ToTable(tb => tb.IsTemporal(ttb =>
                            {
                                ttb.UseHistoryTable("RadiosAudit");
                                ttb
                                    .HasPeriodStart("ValidFrom")
                                    .HasColumnName("ValidFrom");
                                ttb
                                    .HasPeriodEnd("ValidTo")
                                    .HasColumnName("ValidTo");
                            }));
                });

            modelBuilder.Entity("AutoLot.Models.Entities.SeriLogEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ApplicationName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Level")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int?>("LineNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("LogEvent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MachineName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MemberName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MessageTemplate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Properties")
                        .HasColumnType("Xml");

                    b.Property<string>("RequestPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SourceContext")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeStamp")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GetDate()");

                    b.HasKey("Id");

                    b.ToTable("SeriLogs", "Logging");
                });

            modelBuilder.Entity("AutoLot.Models.ViewModels.CustomerOrderViewModel", b =>
                {
                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("DateBuilt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Display")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool?>("IsDrivable")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Make")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PetName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal?>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable((string)null);

                    b.ToView("CustomerOrderView", (string)null);
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Car", b =>
                {
                    b.HasOne("AutoLot.Models.Entities.Make", "MakeNavigation")
                        .WithMany("Cars")
                        .HasForeignKey("MakeId")
                        .IsRequired()
                        .HasConstraintName("FK_Inventory_Makes_MakeId");

                    b.Navigation("MakeNavigation");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.CarDriver", b =>
                {
                    b.HasOne("AutoLot.Models.Entities.Car", "CarNavigation")
                        .WithMany("CarDrivers")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired()
                        .HasConstraintName("FK_InventoryDriver_Inventory_InventoryId");

                    b.HasOne("AutoLot.Models.Entities.Driver", "DriverNavigation")
                        .WithMany("CarDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_InventoryDriver_Drivers_DriverId");

                    b.Navigation("CarNavigation");

                    b.Navigation("DriverNavigation");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.CreditRisk", b =>
                {
                    b.HasOne("AutoLot.Models.Entities.Customer", "CustomerNavigation")
                        .WithMany("CreditRisks")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_CreditRisks_Customers");

                    b.Navigation("CustomerNavigation");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Order", b =>
                {
                    b.HasOne("AutoLot.Models.Entities.Car", "CarNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CarId")
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Inventory");

                    b.HasOne("AutoLot.Models.Entities.Customer", "CustomerNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Orders_Customers");

                    b.Navigation("CarNavigation");

                    b.Navigation("CustomerNavigation");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Radio", b =>
                {
                    b.HasOne("AutoLot.Models.Entities.Car", "CarNavigation")
                        .WithOne("RadioNavigation")
                        .HasForeignKey("AutoLot.Models.Entities.Radio", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarNavigation");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Car", b =>
                {
                    b.Navigation("CarDrivers");

                    b.Navigation("Orders");

                    b.Navigation("RadioNavigation");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Customer", b =>
                {
                    b.Navigation("CreditRisks");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Driver", b =>
                {
                    b.Navigation("CarDrivers");
                });

            modelBuilder.Entity("AutoLot.Models.Entities.Make", b =>
                {
                    b.Navigation("Cars");
                });
#pragma warning restore 612, 618
        }
    }
}
