﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.ProductPage
{
    public class DetailsModel : PageModel
    {
        private readonly RazorNorthwinds.Data.NorthwindsDbContext _context;

        public DetailsModel(RazorNorthwinds.Data.NorthwindsDbContext context)
        {
            _context = context;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            //var product = await _context.Products.FirstOrDefaultAsync(m => m.ProductId == id);

            //var product = await _context.Products
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,
            //        p.SupplierId,
            //        p.CategoryId,
            //        p.QuantityPerUnit,
            //        p.UnitPrice,
            //        p.UnitsInStock,
            //        p.UnitsOnOrder,
            //        p.ReorderLevel,
            //        p.Discontinued,
            //        CategoryName = p.Category.CategoryName,
            //        SupplierName = p.Supplier.CompanyName
            //    })
            //    .FirstOrDefaultAsync(m => m.ProductId == id);

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }
            else
            {
                Product = product;
            }
            return Page();
        }
    }
}