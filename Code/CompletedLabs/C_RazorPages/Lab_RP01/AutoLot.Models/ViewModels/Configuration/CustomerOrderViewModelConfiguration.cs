// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Models - CustomerOrderViewModelConfiguration.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/25
// ==================================

namespace AutoLot.Models.ViewModels.Configuration;

public class CustomerOrderViewModelConfiguration : IEntityTypeConfiguration<CustomerOrderViewModel>
{
    public void Configure(EntityTypeBuilder<CustomerOrderViewModel> builder)
    {
        builder.HasNoKey();
        builder.ToView("CustomerOrderView");
        CultureInfo provider = new("en-us");
        NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
        builder.Property(p => p.Price)
            .HasConversion(
                v => decimal.Parse(v, style, provider),
                v => v.ToString("C2"));
    }
}