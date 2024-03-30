using CQRS1.Model;
using MediatR;

namespace CQRS1.Commands
{
    public record AddProductCommand(Product Product) : IRequest;
}
