//https://code-maze.com/tracing-dotnet-applications-opentelemetry/

using Microsoft.EntityFrameworkCore;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;
using Tracing.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ProductsDataContext>(opts =>
    opts.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Add services to the container.
// Add services to the container.
builder.Services.AddOpenTelemetry()
    .WithTracing(builder => builder
        .AddAspNetCoreInstrumentation(opt =>
        {
            opt.EnrichWithHttpRequest = (activity, httpRequest) => activity.SetBaggage("UserId", "1234");
        })
        .AddHttpClientInstrumentation()
        .AddSqlClientInstrumentation()
        .AddConsoleExporter()
        .AddJaegerExporter()
        .AddSource("Tracing")
        .SetResourceBuilder(
            ResourceBuilder.CreateDefault()
                .AddService(serviceName: "Tracing")))
    .StartWithHost();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
