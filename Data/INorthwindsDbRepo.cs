using RazorNorthwinds.Models;

namespace RazorNorthwinds.Data
{
    public interface INorthwindsDbRepo
    {
        Task AddCustomerAsync(Customer customer);

        Task AddOrderAsync(Order order);

        Task AddProductAsync(Product product);

        Task DeleteCustomerAsync(string id);

        Task DeleteProductAsync(int id);

        Task EventOccurred(Customer customer, string evt);

        Task<IList<Category>> GetCategoriesAsync();

        Task<IList<CategorySalesForYear>> GetCategorySalesForYearAsync(int year);

        Task<Customer?> GetCustomerByIdAsync(string id);

        Task<IList<Customer>> GetCustomersAsync();

        Task<Employee?> GetEmployeeByIdAsync(int id);

        Task<IList<Employee>> GetEmployeesAsync();

        Task<Order?> GetOrderByIdAsync(int id);

        Task<IList<Order>> GetOrdersAsync();

        Task<OrderSubtotal?> GetOrderSubtotalByIdAsync(int id);

        Task<Product?> GetProductByIdAsync(int id);

        Task<IList<ProductSalesForYear>> GetProductSalesForYearAsync(int year);

        Task<IList<Product>> GetProductsAsync();

        Task<IList<Shipper>> GetShippersAsync();

        Task<IList<Supplier>> GetSuppliersAsync();

        Task UpdateCustomerAsync(Customer customer);

        Task UpdateProductAsync(Product product);
    }
}