using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class GetEmployeesHandler : IRequestHandler<GetEmployeesQuery, IList<Employee>>
    {
        private readonly INorthwindsDbRepo _db;

        public GetEmployeesHandler(INorthwindsDbRepo db)
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
        private readonly INorthwindsDbRepo _db;

        public GetEmployeeByIdHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<Employee?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetEmployeeByIdAsync(request.Id);
        }
    }
}