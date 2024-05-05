namespace DIServiceResolution.Services
{

    public interface IServiceB
    {
        public void DoWork();
    }
    public class ServiceB: IServiceB
    {
        public void DoWork() 
        {
            Console.WriteLine("Inside service B");
        }    
    }
}
