
using System;
using System.Threading;
using System.Threading.Tasks;
using MassTransit;
using MassTransit.ActiveMqTransport;
using Microsoft.Extensions.DependencyInjection;

namespace MassTransitActiveMQ
{
    public interface UpdateAccount
    {
        public String AccountNumber { get; set; }
    }
    public interface DeleteAccount
    {
        public String AccountNumber { get; set; }
    }
    public class AccountConsumer : IConsumer<UpdateAccount>
    {
        public Task Consume(ConsumeContext<UpdateAccount> context)
        {
            Console.WriteLine("Command Received: {0}", context.Message.AccountNumber);
            return Task.CompletedTask;
        }
    }
    public class AnotherAccountConsumer : IConsumer<UpdateAccount>
    {
        public Task Consume(ConsumeContext<UpdateAccount> context)
        {
            Console.WriteLine("Another Command Received: {0}", context.Message.AccountNumber);
            return Task.CompletedTask;
        }
    }
    public class Program
    {
        public static async Task Main()
        {
            var busControl = Bus.Factory.CreateUsingActiveMq(cfg =>
            {
                cfg.Host("localhost", h => {
                    h.Username("admin");
                    h.Password("admin");
                    // h.UseSsl
                });
                cfg.ReceiveEndpoint("account-service", e =>
                {
                    e.PrefetchCount = 20;
                    e.Consumer<AccountConsumer>();
                });
                cfg.ReceiveEndpoint("another-account-service", e =>
                {
                    e.PrefetchCount = 20;
                    e.Consumer<AnotherAccountConsumer>();
                });
            });
            using var cancellation = new CancellationTokenSource(TimeSpan.FromSeconds(30));
            
            // it will always try to connect to the broker, thats way added a cancellation token 
            await busControl.StartAsync(cancellation.Token);
            try
            {
                // mass transit used to create a temporary queue, since I am not doing anything, now it just doesnot 
                Console.WriteLine("Bus has been started");
                var endpoint = await busControl.GetSendEndpoint(new Uri("queue:account-service"));
                await endpoint.Send<UpdateAccount>(new
                {
                    AccountNumber = "12345:queue:account-service",
                });
                await endpoint.Send<DeleteAccount>(new
                {
                    AccountNumber = "12345",
                });
                await busControl.Publish<UpdateAccount>(new
                {
                    AccountNumber = "12345:publish",
                });
                await Task.Run(Console.ReadLine);
            }
            finally
            {
                await busControl.StopAsync(CancellationToken.None);
            }
        }
    }
}
