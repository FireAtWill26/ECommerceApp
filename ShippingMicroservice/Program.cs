using JwtAuthenticationManager;
using Microsoft.EntityFrameworkCore;
using ShippingMicroservice.ApplicationCore.Contracts.Repositories;
using ShippingMicroservice.ApplicationCore.Contracts.Services;
using ShippingMicroservice.Infrastructure.Data;
using ShippingMicroservice.Infrastructure.Repositories;
using ShippingMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtTokenHandler>();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IShipperRepositoryAsync, ShipperRepositoryAsync>();
builder.Services.AddScoped<IShipperServiceAsync,ShipperServiceAsync>();
builder.Services.AddScoped<IShippingDetailRepositoryAsync, ShippingDetailRepositoryAsync>();
builder.Services.AddScoped<IShippingDetailServiceAsync, ShippingDetailServiceAsync>();

//builder.Services.AddDbContext<ECommerceDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));
//});

builder.Services.AddDbContext<ECommerceDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("ShipperConnectionDb"));
});

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
