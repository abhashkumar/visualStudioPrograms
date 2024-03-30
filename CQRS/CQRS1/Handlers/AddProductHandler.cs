using CQRS1.Commands;
using CQRS1.DataStore;
using MediatR;

namespace CQRS1.Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand>
    {
        private readonly FakeDataStore _fakeDataStore;

        public AddProductHandler(FakeDataStore fakeDataStore) => _fakeDataStore = fakeDataStore;

        public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fakeDataStore.AddProduct(request.Product);

            return;
        }
    }
}
