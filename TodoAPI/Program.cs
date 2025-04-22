// program.cs
using DBSettings;
using TodoAPI.Models;
using TodoAPI.Services;
using TodoAPI.Interface;
using TodoAPI.Middleware;
using TodoAPI.AppDataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

var builder = WebApplication.CreateBuilder(args); // used to configure and build the application's services and middleware pipeline, effectively acting as the container for the application's dependencies

// Add services to the container.
builder.Services.AddControllers(); // Adds controller services to the application
builder.Services.AddEndpointsApiExplorer(); // Adds support for discovering API endpoints
builder.Services.AddSwaggerGen(); // Adds support for generating Swagger documentation
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());//Add with mapping

// Register the DbContext with SQLite
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))); // Use SQLite

// Register your ITodoServices and its implementation
builder.Services.AddScoped<ITodoServices, TodoServices>();

//add with exception middleware
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.AddLogging();

// Add the ConfigureServices method
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddDbContext<TodoDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build(); // Builds the application

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enables middleware to serve generated Swagger as a JSON endpoint
    app.UseSwaggerUI(); // Enables middleware to serve Swagger UI
}

app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS

// Configure the exception handler middleware
app.UseExceptionHandler("/error"); // Redirects to the /error endpoint in case of an exception

app.UseAuthorization(); // Adds authorization middleware
app.MapControllers(); // Maps controller routes

app.Map("/error", (HttpContext httpContext) =>
{
    // Custom error handling logic
    return Results.Problem("An unexpected error occurred.");
});

app.Run(); // Runs the application