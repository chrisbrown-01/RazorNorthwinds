using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorNorthwinds.Data;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.OrderPage
{
    public class CreateModel : PageModel
    {
        private readonly RazorNorthwinds.Data.NorthwindsDbContext _context;

        public CreateModel(RazorNorthwinds.Data.NorthwindsDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
        ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "EmployeeId");
        ViewData["ShipVia"] = new SelectList(_context.Shippers, "ShipperId", "ShipperId");
            return Page();
        }

        [BindProperty]
        public Order Order { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Orders == null || Order == null)
            {
                return Page();
            }

            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
