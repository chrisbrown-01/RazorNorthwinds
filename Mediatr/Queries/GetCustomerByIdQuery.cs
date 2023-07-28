﻿using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetCustomerByIdQuery(string Id) : IRequest<Customer?>;
}