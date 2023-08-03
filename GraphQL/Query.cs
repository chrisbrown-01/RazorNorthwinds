using MediatR;
using RazorNorthwinds.Mediatr.Queries;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.GraphQL
{
    public class Query
    {
        private readonly IMediator _mediator;

        public Query(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IList<Customer>> GetCustomersAsync()
        {
            return await _mediator.Send(new GetCustomersQuery());
        }

        public async Task<Customer?> GetCustomerByIdAsync(string id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(id));
        }

        public async Task<IList<Product>> GetProductsAsync()
        {
            return await _mediator.Send(new GetProductsQuery());
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _mediator.Send(new GetProductByIdQuery(id));
        }

        public async Task<IList<Category>> GetCategoriesAsync()
        {
            return await _mediator.Send(new GetCategoriesQuery());
        }

        public async Task<IList<Supplier>> GetSuppliersAsync()
        {
            return await _mediator.Send(new GetSuppliersQuery());
        }

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            return await _mediator.Send(new GetEmployeesQuery());
        }

        public async Task<Employee?> GetEmployeeByIdAsync(int id)
        {
            return await _mediator.Send(new GetEmployeeByIdQuery(id));
        }

        public async Task<IList<Order>> GetOrderAsync()
        {
            return await _mediator.Send(new GetOrdersQuery());
        }

        public async Task<Order?> GetOrderByIdAsync(int id)
        {
            return await _mediator.Send(new GetOrderByIdQuery(id));
        }

        public async Task<OrderSubtotal?> GetOrderSubtotalByIdAsync(int id)
        {
            return await _mediator.Send(new GetOrderSubtotalByIdQuery(id));
        }

        public async Task<IList<Shipper>> GetShippersAsync()
        {
            return await _mediator.Send(new GetShippersQuery());
        }

        public async Task<IList<ProductSalesForYear>> GetProductSalesForYearAsync(int year)
        {
            return await _mediator.Send(new GetProductSalesForYearQuery(year));
        }

        public async Task<IList<CategorySalesForYear>> GetCategorySalesForYearAsync(int year)
        {
            return await _mediator.Send(new GetCategorySalesForYearQuery(year));
        }
    }
}