using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Commands
{
    public record AddCustomerCommand(Customer Customer) : IRequest;
}