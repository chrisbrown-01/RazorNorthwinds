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

        private bool CustomerExists(string id) // TODO: make public
        {
            return (_context.Customers?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }
    }
}