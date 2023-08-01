using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetEmployeesQuery() : IRequest<IList<Employee>>;
    public record GetEmployeeByIdQuery(int Id) : IRequest<Employee?>;
}