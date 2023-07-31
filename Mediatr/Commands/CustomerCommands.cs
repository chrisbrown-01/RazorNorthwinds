using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Commands
{
    public record AddCustomerCommand(Customer Customer) : IRequest;
    public record UpdateCustomerCommand(Customer Customer) : IRequest;
    public record DeleteCustomerCommand(string Id) : IRequest;
}