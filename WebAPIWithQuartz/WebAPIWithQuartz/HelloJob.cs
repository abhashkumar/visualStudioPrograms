using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIWithQuartz
{
	public class HelloJob : IJob
	{
		private readonly ILogger<HelloJob> _logger;
		public HelloJob(ILogger<HelloJob> logger)
		{
			_logger = logger;
		}
		public async Task Execute(IJobExecutionContext context)
		{
			await Console.Out.WriteLineAsync("Greetings from HelloJob!");
		}
	}
}
