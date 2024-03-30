using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Threading;

namespace helloDotnet5
{
    public class WhetherClient
    {
        private readonly HttpClient httpClient;
        private readonly ServiceSettings settings;
        public WhetherClient(HttpClient httpClient, IOptions<ServiceSettings> options)
        {
            this.httpClient = httpClient;
            this.settings = options.Value;
        }
        public record Weather(string description);
        public record Main(decimal temp);

        public record Forcast(Weather[] weather, Main main, long dt);

        public async Task<Forcast> GetCurrentWhetherAsync(string city)
        {
            var forcast = await httpClient.GetFromJsonAsync<Forcast>($"https://{settings.OpenWeatherHost}/data/2.5/weather?q={city}&appid={settings.ApiKey}&units=metric");
            return forcast;
        }
    }
}
