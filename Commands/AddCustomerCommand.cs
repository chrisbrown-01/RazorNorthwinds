using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Commands
{
    public record AddCustomerCommand(Customer Customer) : IRequest;
}