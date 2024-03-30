using Microsoft.Extensions.Hosting;
using Quartz;
using System;

namespace QuartzPract
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
                // Add the required Quartz.NET services
                services.AddQuartz(q =>
                {
                    q.UseMicrosoftDependencyInjectionScopedJobFactory();
                    q.AddJobAndTrigger<HelloWorldJob>(hostContext.Configuration);
                    q.AddJobAndTrigger<MyWorldJob>(hostContext.Configuration);
                });

                // Add the Quartz.NET hosted service

                services.AddQuartzHostedService(
                q => q.WaitForJobsToComplete = true);

                // other config
            });
    }
}
