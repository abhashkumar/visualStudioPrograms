using Microsoft.AspNetCore.Authentication.Cookies;
using Octokit;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = "GitHub";
        })
        .AddCookie(options =>
        {
            options.ExpireTimeSpan = TimeSpan.FromMinutes(20); // Set an absolute expiration time (e.g., 30 minutes)
            options.SlidingExpiration = true; // Enable sliding expiration
        })
        .AddOAuth("GitHub", options =>
        {
            options.ClientId = "";
            options.ClientSecret = "";
            options.CallbackPath = new PathString("/signin-github");
            options.AuthorizationEndpoint = "https://github.com/login/oauth/authorize";
            options.TokenEndpoint = "https://github.com/login/oauth/access_token";
            options.SaveTokens = true;

            // Add any additional scopes required
            options.Scope.Add("email");
            options.Scope.Add("user");
            options.Scope.Add("offline_access");
        });

        builder.Services.AddControllersWithViews();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication(); // Ensure authentication middleware is added before authorization middleware
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}