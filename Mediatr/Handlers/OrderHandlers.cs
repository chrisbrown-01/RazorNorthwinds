using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class AddOrderHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly INorthwindsDbRepo _db;

        public AddOrderHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            // Add random order details
            var numOfOrderDetails = Random.Shared.Next(1, 6);

            for (int i = 0; i < numOfOrderDetails; i++)
            {
                request.Order.OrderDetails.Add(new OrderDetail
                {
                    ProductId = Random.Shared.Next(1, 50),
                    UnitPrice = (decimal)Math.Round(Random.Shared.NextDouble() * 100 + 1.00, 1),
                    Quantity = (short)Random.Shared.Next(1, 11),
                }); ;
            }

            await _db.AddOrderAsync(request.Order);
        }
    }

    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, IList<Order>>
    {
        private readonly INorthwindsDbRepo _db;

        public GetOrdersHandler(INorthwindsDbRepo db)
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
        private readonly INorthwindsDbRepo _db;

        public GetOrderByIdHandler(INorthwindsDbRepo db)
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
        private readonly INorthwindsDbRepo _db;

        public GetOrderSubtotalByIdHandler(INorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<OrderSubtotal?> Handle(GetOrderSubtotalByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetOrderSubtotalByIdAsync(request.Id);
        }
    }
}