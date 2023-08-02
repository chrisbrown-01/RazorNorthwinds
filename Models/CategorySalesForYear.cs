namespace RazorNorthwinds.Models
{
    public class CategorySalesForYear
    {
        public int Year { get; set; }
        public string CategoryName { get; set; } = null!;

        public decimal? CategorySales { get; set; }
    }
}