using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Oauth2._0.Controllers
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


        [Authorize]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("/signin-github")]
        public async Task<IActionResult> GitHubSignInCallback()
        {
            var authenticateResult = await HttpContext.AuthenticateAsync("GitHub");

            if (authenticateResult.Succeeded)
            {
                // Authentication succeeded, handle it accordingly
                return RedirectToAction("Authenticated", "Home");
            }
            else
            {
                // Authentication failed, handle it accordingly
                return RedirectToAction("AuthenticationFailed", "Home");
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("Logged out successfully!");
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var result = await HttpContext.AuthenticateAsync();
            if (!result.Succeeded || result.Properties == null)
            {
                return Unauthorized();
            }

            var refreshToken = result.Properties.GetTokenValue("refresh_token");
            if (string.IsNullOrEmpty(refreshToken))
            {
                return BadRequest("Refresh token not found.");
            }

            // Send the refresh token to the OAuth2 provider to obtain a new access token
            // Here you would make a request to the OAuth2 provider's token endpoint using the refresh token

            // For demonstration purposes, let's assume we already obtained a new access token
            var newAccessToken = "new-access-token";

            // Update the authentication ticket with the new access token
            var authProperties = new AuthenticationProperties((IDictionary<string, string?>)result.Properties);
            authProperties.UpdateTokenValue("access_token", newAccessToken);

            await HttpContext.SignInAsync(result.Principal, authProperties);

            return Ok(newAccessToken);
        }
    }
}