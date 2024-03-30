using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzPract
{
    class MyWorldJob: IJob
    {
        private readonly ILogger<MyWorldJob> _logger;
        public MyWorldJob(ILogger<MyWorldJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("My world!");
            return Task.CompletedTask;
        }
    }
}
