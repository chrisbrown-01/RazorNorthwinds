using MediatR;
using RazorNorthwinds.Data;
using RazorNorthwinds.Mediatr.Commands;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public AddProductHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _db.AddProductAsync(request.Product);
        }
    }

    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public UpdateProductHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _db.UpdateProductAsync(request.Product);
        }
    }

    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly NorthwindsDbRepo _db;

        public DeleteProductHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _db.DeleteProductAsync(request.Id);
        }
    }

    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IList<Product>>
    {
        private readonly NorthwindsDbRepo _db;

        public GetProductsHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<IList<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetProductsAsync();
        }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product?>
    {
        private readonly NorthwindsDbRepo _db;

        public GetProductByIdHandler(NorthwindsDbRepo db)
        {
            _db = db;
        }

        public async Task<Product?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await _db.GetProductByIdAsync(request.Id);
        }
    }
}