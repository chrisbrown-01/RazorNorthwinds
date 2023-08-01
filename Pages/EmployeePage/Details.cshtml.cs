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
    public class DetailsModel : PageModel
    {
        private readonly RazorNorthwinds.Data.NorthwindsDbContext _context;

        public DetailsModel(RazorNorthwinds.Data.NorthwindsDbContext context)
        {
            _context = context;
        }

      public Employee Employee { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Employees == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees.FirstOrDefaultAsync(m => m.EmployeeId == id);
            if (employee == null)
            {
                return NotFound();
            }
            else 
            {
                Employee = employee;
            }
            return Page();
        }
    }
}
