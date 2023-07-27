using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

using Micro.OrderManagementService.Application.Interfaces;
using Micro.OrderManagementService.Application.Services;
using Micro.OrderManagementService.Domain.Models;
using Micro.OrderManagementService.Infraestructure.Context;
using Micro.OrderManagementService.Infraestructure.Repository;
using MicroBroker.OrderManagementService.Domain.Interfaces;
using Micro.OrderManagementService.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// MongoDB Configuration
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoDb"));
builder.Services.AddSingleton<IMongoDatabase>(sp =>
{
	var settings = sp.GetRequiredService<IOptions<MongoSettings>>().Value;
	var client = new MongoClient(settings.ConnectionString);
	return client.GetDatabase(settings.DatabaseName);
});

// DbContext
builder.Services.AddSingleton<GlobalDbContext>();

// Repositories
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderLineRepository, OrderLineRepository>();




// Services
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IOrderLineService, OrderLineService>();
builder.Services.AddTransient<IOrderService, OrderService>();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors(options =>
{
	options.AllowAnyOrigin(); // Permitir cualquier origen
	options.AllowAnyMethod(); // Permitir cualquier método (GET, POST, etc.)
	options.AllowAnyHeader(); // Permitir cualquier encabezado
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
