using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.EmployeePage
{
    public class IndexModel : PageModel
    {
        private readonly RazorNorthwinds.Data.NorthwindsDbContext _context;

        public IndexModel(RazorNorthwinds.Data.NorthwindsDbContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Employees != null)
            {
                Employee = await _context.Employees
                .Include(e => e.ReportsToNavigation).ToListAsync();
            }
        }
    }
}
