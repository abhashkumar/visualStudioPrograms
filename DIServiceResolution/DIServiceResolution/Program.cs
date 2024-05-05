using DIServiceResolution.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// dependent sevice service, dependency service B, A -> B
/*
 * A singleton service lifetime cannot inject a scoped service lifetime directly.(the only issue)
 * A service with a singleton lifetime would not know which scope instance it belongs to, so an exception would be thrown.
   In-order to use a service with a scoped lifetime in a singleton service lifetime class, you would have to explictly create a scope within it and then use that scope to resolve the instance.
 */


 builder.Services.AddSingleton<IServiceA, ServiceA>();
// builder.Services.AddScoped<IServiceA, ServiceA>();
// builder.Services.AddTransient<IServiceA, ServiceA>();
//  builder.Services.AddSingleton<IServiceB, ServiceB>();
  builder.Services.AddScoped<IServiceB, ServiceB>();
// builder.Services.AddTransient<IServiceB, ServiceB>();

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
