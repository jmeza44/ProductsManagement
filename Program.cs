using Microsoft.EntityFrameworkCore;
using ProductsManagement.Data;
using ProductsManagement.Data.Services;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ProductsManagement.Data.AppDbContext>(opt => opt.UseSqlServer(connectionString));
builder.Services.AddTransient<ProductsService>();
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

app.UseAuthorization();

app.MapControllers();

AppDbInitializer.Seed(app);

app.Run();
