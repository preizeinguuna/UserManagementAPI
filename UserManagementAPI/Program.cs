using UserManagementAPI.Models;
using UserManagementAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Error Handling FIRST
app.UseMiddleware<ErrorHandlingMiddleware>();

// Authentication SECOND
app.UseMiddleware<AuthenticationMiddleware>();

// Logging LAST
app.UseMiddleware<LoggingMiddleware>();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();