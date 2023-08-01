using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Data
{
    public class NorthwindsDbRepo // TODO: implement interface, use DI
    {
        private readonly NorthwindsDbContext _context;

        public NorthwindsDbRepo(NorthwindsDbContext context)
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

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // TODO: improvements?
            {
                throw;
            }
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

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) // TODO: improvements?
            {
                throw;
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return;// TODO: logger message or throw exception
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

        private bool CustomerExists(string id) // TODO: make public
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}