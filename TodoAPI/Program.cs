// program.cs
using DBSettings;
using TodoAPI.AppDataContext;
using TodoAPI.models;

var builder = WebApplication.CreateBuilder(args); // used to configure and build the application's services and middleware pipeline, effectively acting as the container for the application's dependencies

// Add services to the container.
builder.Services.AddControllers(); // Adds controller services to the application

builder.Services.AddEndpointsApiExplorer(); // Adds support for discovering API endpoints
builder.Services.AddSwaggerGen(); // Adds support for generating Swagger documentation

// Registering DbContext to enable usage of TodoDbContext for interacting with the database
builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings")); // Configures DbSettings from appsettings.json
builder.Services.AddSingleton<TodoDbContext>(); // Registers TodoDbContext as a singleton service

var app = builder.Build(); // Builds the application

// Create a scope to get the service provider
{
    using var scope = app.Services.CreateScope(); // Creates a scope for resolving scoped services
    var context = scope.ServiceProvider; // Gets the service provider from the scope
}

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