using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using OrderMicroservice.ApplicationCore.Contracts.Repositories;
using OrderMicroservice.ApplicationCore.Contracts.Services;
using OrderMicroservice.Infrastructure.Data;
using OrderMicroservice.Infrastructure.Repositories;
using OrderMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ECommerceDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));
//});


var ConnectionStrinng = Environment.GetEnvironmentVariable("OrderConnectionDb");

builder.Services.AddDbContext<ECommerceDbContext>(option =>
{
    option.UseSqlServer(ConnectionStrinng);
    //option.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});



//Dependency Injection for repositories
builder.Services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
builder.Services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
builder.Services.AddScoped<IPaymentRepositoryAsync, PaymentRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartRepositoryAsync, ShoppingCartRepositoryAsync>();
builder.Services.AddScoped<IShoppingCartItemRepositoryAsync, ShoppingCartItemRepositoryAsync>();

//Dependency Injection for services
builder.Services.AddScoped<ICustomerServiceAsync, CustomerServiceAsync>();
builder.Services.AddScoped<IOrderServiceAsync, OrderServiceAsync>();
builder.Services.AddScoped<IPaymentServiceAsync, PaymentServiceAsync>();
builder.Services.AddScoped<IShoppingCartServiceAsync, ShoppingCartServiceAsync>();
builder.Services.AddScoped<IShoppingCartItemServiceAsync, ShoppingCartItemServiceAsync>();




builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

app.UseAuthorization();

app.MapControllers();

app.Run();
