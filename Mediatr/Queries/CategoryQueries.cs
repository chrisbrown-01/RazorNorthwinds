using MediatR;
using RazorNorthwinds.Models;

namespace RazorNorthwinds.Mediatr.Queries
{
    public record GetCategoriesQuery() : IRequest<IList<Category>>;
}