﻿using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetProductSalesForYearQuery(int Year) : IRequest<IList<ProductSalesForYear>>;
    public record GetCategorySalesForYearQuery(int Year) : IRequest<IList<CategorySalesForYear>>;
}