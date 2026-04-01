using ApplicationService;
using Infrastructure;
using Components.Framework.WebApplicationExtensions;
using Components.Framework.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerService();

string? connectionString = builder.Configuration.GetConnectionString("SqlServer");

builder.Services.RegisterDbContext(connectionString);
builder.Services.RegisterRepositories();
builder.Services.RegisterHandlers();

var app = builder.Build();

app.UseCustomExceptionHandler();

app.UseSwaggerInDevelopment();

app.MapControllers();

app.Run();