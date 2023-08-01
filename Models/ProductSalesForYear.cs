using System;
using System.Collections.Generic;

namespace RazorNorthwinds.Models;

public class ProductSalesForYear
{
    public int Year { get; set; }
    public string CategoryName { get; set; } = null!;

    public string ProductName { get; set; } = null!;

    public decimal? ProductSales { get; set; }
}