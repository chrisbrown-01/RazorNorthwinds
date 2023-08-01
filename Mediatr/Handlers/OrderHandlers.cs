using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public AddOrderHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            await _db.AddOrderAsync(request.Order);
        }
    }

    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IList<Order>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetOrdersHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetOrdersAsync();
        }
    }

    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, Order?>
    {
        private readonly NorthwindsDbRepo _db;

        public GetOrderByIdHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<Order?> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetOrderByIdAsync(request.Id);
        }
    }

    public class GetOrderSubtotalByIdHandler : IRequestHandler<GetOrderSubtotalByIdQuery, OrderSubtotal?>
    {
        private readonly NorthwindsDbRepo _db;

        public GetOrderSubtotalByIdHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<OrderSubtotal?> Handle(GetOrderSubtotalByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetOrderSubtotalByIdAsync(request.Id);
        }
    }
}