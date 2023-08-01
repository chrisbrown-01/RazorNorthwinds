using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.OrderPage
{
    public class IndexModel : PageModel
    {
        private readonly RazorNorthwinds.Data.NorthwindsDbContext _context;

        public IndexModel(RazorNorthwinds.Data.NorthwindsDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Orders != null)
            {
                Order = await _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.Employee)
                .Include(o => o.ShipViaNavigation).ToListAsync();
            }
        }
    }
}
