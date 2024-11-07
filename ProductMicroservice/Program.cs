using Microsoft.EntityFrameworkCore;
using ProductMicroservice.ApplicationCore.Contracts.Repositories;
using ProductMicroservice.ApplicationCore.Contracts.Services;
using ProductMicroservice.Infrastructure.Data;
using ProductMicroservice.Infrastructure.Repositories;
using ProductMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<ECommerceDbContext>(option => {
//    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb")); 
//    });

builder.Services.AddDbContext<ECommerceDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("ProductConnectionDb"));
});

//Dependency Injection for repositories
builder.Services.AddScoped<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
builder.Services.AddScoped<ICategoryVariationRepositoryAsync, CategoryVariationRepositoryAsync>();
builder.Services.AddScoped<IProductRepositoryAsync, ProductRepositoryAsync>();
builder.Services.AddScoped<IProductVariationRepositoryAsync, ProductVariationRepositoryAsync>();
builder.Services.AddScoped<IVariationValueRepositoryAsync, VariationValueRepositoryAsync>();

//Dependency Injection for services
builder.Services.AddScoped<ICategoryServiceAsync, CategoryServiceAsync>();
builder.Services.AddScoped<ICategoryVariationServiceAsync, CategoryVariationServiceAsync>();
builder.Services.AddScoped<IProductServiceAsync, ProductServiceAsync>();
builder.Services.AddScoped<IProductVariationServiceAsync, ProductVariationServiceAsync>();
builder.Services.AddScoped<IVariationValueServiceAsync, VariationValueServiceAsync>();



builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
