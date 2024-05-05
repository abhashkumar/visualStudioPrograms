
namespace DIServiceResolution.Services
{

    public interface IServiceA
    {
        public void DoWork();
    }
    public class ServiceA: IServiceA
    {
        IServiceB serviceB;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public ServiceA(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void DoWork() 
        {
            Console.WriteLine("Inside service A");
            serviceB.DoWork();
            // Create a new scope
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                // Resolve the scoped service within the scope
                var scopedService = scope.ServiceProvider.GetRequiredService<IServiceB>();

                // Use the scoped service
                scopedService.DoWork();
            }
        }
    }
}
