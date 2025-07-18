
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 🔌 Add services to the container


// Add Controllers
builder.Services.AddControllers();

// (Optional) Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Swagger for API Documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "KaleNation Ticketing API",
        Version = "v1",
        Description = "API for managing events, tickets, users, and payments"
    });
});

var app = builder.Build();

// 📦 Configure the HTTP request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use HTTPS
app.UseHttpsRedirection();

// Use CORS (optional)
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
