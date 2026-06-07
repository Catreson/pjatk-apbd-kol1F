using Microsoft.EntityFrameworkCore;
using Kol1.Data;     // your namespace
using Kol1.Services; // your namespace

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Register EF Core - reads connection string from appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Register your services here, one line per service:
// builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "v1");
        opt.RoutePrefix = string.Empty; // Swagger at http://localhost:PORT/
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();