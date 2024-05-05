namespace DIServiceResolution.Services
{

    public interface IServiceC
    {
        public void DoWork();
    }
    public class ServiceC : IServiceC
    {
        public void DoWork()
        {
            Console.WriteLine("Inside service B");
        }
    }
}
