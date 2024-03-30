using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace webAPISql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            string name = "";
            using (SqlConnection connection = new SqlConnection(@"Server = .\SQLEXPRESS; Database = master; Trusted_Connection = True;TrustServerCertificate=True"))
            {
                using (SqlCommand cmd = new SqlCommand("Select * from dbo.People", connection))
                {
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string id = reader.GetString(0);
                        string FirstName = reader.GetString(1);
                        string LastName = reader.GetString(2);
                        string EmailAddress = reader.GetString(3);
                        string PhoneNumber = reader.GetString(4);
                        //Console.WriteLine($"{id} {FirstName} {LastName} {EmailAddress} {PhoneNumber}");
                        name = FirstName;
                    }
                }
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                FirstName = name
            })
            .ToArray();
        }
    }
}
