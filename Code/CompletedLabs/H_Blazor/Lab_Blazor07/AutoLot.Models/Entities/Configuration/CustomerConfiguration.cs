﻿// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - CustomerConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/12/3
// ==================================

namespace AutoLot.Models.Entities.Configuration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder
            .Property(e => e.TimeStamp)
            .HasConversion<byte[]>();

        builder.ToTable(b => b.IsTemporal(t =>
        {
            t.HasPeriodEnd("ValidTo");
            t.HasPeriodStart("ValidFrom");
            t.UseHistoryTable("CustomerAudit");
        }));

        builder.ComplexProperty(cp => cp.PersonInformation,
            pd =>
            {
                pd.Property<string>(nameof(Person.FirstName))
                    .HasColumnName(nameof(Person.FirstName))
                    .HasColumnType("nvarchar(50)");
                pd.Property<string>(nameof(Person.LastName))
                    .HasColumnName(nameof(Person.LastName))
                    .HasColumnType("nvarchar(50)");
                pd.Property(p => p.FullName)
                    .HasColumnName(nameof(Person.FullName))
                    .HasComputedColumnSql("[LastName] + ', ' + [FirstName]");
                pd.IsRequired(true);
            });
    }
}
