using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Pages.ProductPage
{
    public class DetailsModel : PageModel
    {
        private readonly IMediator _mediator;

        public DetailsModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Product Product { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
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

            var product = await _mediator.Send(new GetProductByIdQuery(id));

            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }
    }
}