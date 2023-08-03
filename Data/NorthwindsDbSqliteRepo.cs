using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Data
{
    public class NorthwindsDbSqliteRepo : INorthwindsDbRepo
    {
        private readonly NorthwindsDbSqliteContext _context;

        public NorthwindsDbSqliteRepo(NorthwindsDbSqliteContext context)
        {
            _context = context;
        }

        #region Customer Methods

        public async Task AddCustomerAsync(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Attach(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCustomerAsync(string id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            return await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId.ToLower() == id.ToLower());
        }

        public async Task EventOccurred(Customer customer, string evt)
        {
            var _customer = await _context.Customers.SingleOrDefaultAsync(c => c.CustomerId.ToLower() == customer.CustomerId.ToLower());
            if (_customer == null) return;
            _customer.Region = evt;
            await _context.SaveChangesAsync();
        }

        #endregion Customer Methods

        #region Product Methods

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(p => p.ProductId == id);
        }

        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            _context.Attach(product).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return;
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        #endregion Product Methods

        #region Category Methods

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        #endregion Category Methods

        #region Supplier Methods

        public async Task<IList<Supplier>> GetSuppliersAsync()
        {
            return await _context.Suppliers.ToListAsync();
        }

        #endregion Supplier Methods

        #region Employee Methods

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _context.Employees
                .Include(e => e.ReportsToNavigation)
                .Include(e => e.Territories)
                .FirstOrDefaultAsync(m => m.EmployeeId == id);
        }

        #endregion Employee Methods

        #region Order Methods

        public async Task AddOrderAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }

        public async Task<IList<Order>> GetOrdersAsync()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .Include(o => o.ShipViaNavigation)
                .FirstOrDefaultAsync(m => m.OrderId == id);
        }

        public async Task<OrderSubtotal?> GetOrderSubtotalByIdAsync(int id)
        {
            if (await _context.OrderDetails.AnyAsync(o => o.OrderId == id) == false) return null;

            return new OrderSubtotal()
            {
                OrderId = id,
                Subtotal = (decimal)Random.Shared.Next(0, 1000)
            };
        }

        #endregion Order Methods

        #region Shipper Methods

        public async Task<IList<Shipper>> GetShippersAsync()
        {
            return await _context.Shippers.ToListAsync();
        }

        #endregion Shipper Methods

        #region Sales Methods

        public async Task<IList<ProductSalesForYear>> GetProductSalesForYearAsync(int year)
        {
            var products = _context.Products.AsEnumerable();
            var productSalesForYear = new List<ProductSalesForYear>();

            foreach (var product in products)
            {
                productSalesForYear.Add(new ProductSalesForYear
                {
                    Year = 1997,
                    ProductName = product.ProductName,
                    CategoryName = product.CategoryId?.ToString() ?? "",
                    ProductSales = (decimal)Random.Shared.Next(1, 50000)
                });
            }

            foreach (var product in productSalesForYear)
            {
                switch (product.CategoryName)
                {
                    case "1":
                        product.CategoryName = "Beverages";
                        break;

                    case "2":
                        product.CategoryName = "Condiments";
                        break;

                    case "3":
                        product.CategoryName = "Confections";
                        break;

                    case "4":
                        product.CategoryName = "Dairy Products";
                        break;

                    case "5":
                        product.CategoryName = "Grains/Cereals";
                        break;

                    case "6":
                        product.CategoryName = "Meat/Poultry";
                        break;

                    case "7":
                        product.CategoryName = "Produce";
                        break;

                    case "8":
                        product.CategoryName = "Seafood";
                        break;

                    default:
                        product.CategoryName = "Seafood";
                        break;
                }
            }

            return await Task.FromResult(productSalesForYear);
        }

        public async Task<IList<CategorySalesForYear>> GetCategorySalesForYearAsync(int year)
        {
            var productSalesForYear = await GetProductSalesForYearAsync(year);

            var result = productSalesForYear
                .GroupBy(p => p.CategoryName)
                .Select(g => new CategorySalesForYear
                {
                    Year = year,
                    CategoryName = g.Key,
                    CategorySales = g.Sum(x => x.ProductSales)
                })
                .ToList();

            return result;
        }

        #endregion Sales Methods
    }
}