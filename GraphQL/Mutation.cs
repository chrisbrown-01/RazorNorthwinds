using MediatR;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;
using System.ComponentModel.DataAnnotations;

namespace RazorNorthwinds.GraphQL
{
    // Mutations require a return type/response
    public class Mutation
    {
        private readonly IMediator _mediator;

        public Mutation(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<Customer> AddCustomerAsync(CustomerInput input)
        {
            var customer = new Customer
            {
                CustomerId = input.CustomerId,
                CompanyName = input.CompanyName,
                ContactName = input.ContactName,
                ContactTitle = input.ContactTitle,
                Address = input.Address,
                City = input.City
            };

            await _mediator.Send(new AddCustomerCommand(customer));
            return customer;
        }

        public async Task<Customer?> UpdateCustomerAsync(CustomerInput input)
        {
            var customer = new Customer
            {
                CustomerId = input.CustomerId,
                CompanyName = input.CompanyName,
                ContactName = input.ContactName,
                ContactTitle = input.ContactTitle,
                Address = input.Address,
                City = input.City
            };

            await _mediator.Send(new UpdateCustomerCommand(customer));
            return await _mediator.Send(new GetCustomerByIdQuery(input.CustomerId));
        }

        public async Task<bool> DeleteCustomerAsync(string customerId)
        {
            try
            {
                await _mediator.Send(new DeleteCustomerCommand(customerId));
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Note that custom validations or 3rd party libraries are required
        // (outside of CustomerId/CompanyName non-null fields). Attributes do not work
        public class CustomerInput
        {
            public string CustomerId { get; set; } = null!;

            public string CompanyName { get; set; } = null!;

            public string? ContactName { get; set; }

            public string? ContactTitle { get; set; }

            public string? Address { get; set; }

            public string? City { get; set; }
        }
    }
}