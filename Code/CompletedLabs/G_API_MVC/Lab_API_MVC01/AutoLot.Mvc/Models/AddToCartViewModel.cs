// Copyright Information
// ==================================
// AutoLot8 - AutoLot.Mvc - AddToCartViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2023/11/26
// ==================================

namespace AutoLot.Mvc.Models;

public class AddToCartViewModel
{
    public int Id { get; set; }
    [Display(Name="Stock Quantity")] public int StockQuantity { get; set; }
    public int ItemId { get; set; }
    [Required, MustBeGreaterThanZero, MustNotBeGreaterThan(nameof(StockQuantity))]
    public int Quantity { get; set; }
}