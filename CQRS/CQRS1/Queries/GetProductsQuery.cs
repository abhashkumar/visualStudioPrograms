using CQRS1.Model;
using MediatR;

namespace CQRS1.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
