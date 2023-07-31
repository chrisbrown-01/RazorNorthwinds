﻿using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class AddCustomerHandler : IRequestHandler<AddCustomerCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public AddCustomerHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            await _db.AddCustomerAsync(request.Customer);
        }
    }

    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public UpdateCustomerHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _db.UpdateCustomerAsync(request.Customer);
        }
    }

    public class DeleteCustomerHandler : IRequestHandler<DeleteCustomerCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public DeleteCustomerHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _db.DeleteCustomerAsync(request.Id);
        }
    }

    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, Customer?>
    {
        private readonly NorthwindsDbRepo _db;

        public GetCustomerByIdHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<Customer?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCustomerByIdAsync(request.Id);
        }
    }

    public class GetCustomersHandler : IRequestHandler<GetCustomersQuery, IList<Customer>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetCustomersHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetCustomersAsync();
        }
    }
}