using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IList<Employee>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetEmployeesHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Employee>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetEmployeesAsync();
        }
    }

    public class GetEmployeeByIdHandler : IRequestHandler<GetEmployeeByIdQuery, Employee?>
    {
        private readonly NorthwindsDbRepo _db;

        public GetEmployeeByIdHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetEmployeeByIdAsync(request.Id);
        }
    }
}