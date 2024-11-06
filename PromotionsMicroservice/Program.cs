using Microsoft.EntityFrameworkCore;
using PromotionsMicroservice.ApplicationCore.Contracts.Repositories;
using PromotionsMicroservice.ApplicationCore.Contracts.Services;
using PromotionsMicroservice.Helper.Mappers;
using PromotionsMicroservice.Infrastructure.Data;
using PromotionsMicroservice.Infrastructure.Repositories;
using PromotionsMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IPromotionRepositoryAsync, PromotionRepositoryAsync>();
builder.Services.AddScoped<IPromotionServiceAsync, PromotionServiceAsync>();



builder.Services.AddDbContext<ECommerceDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("PromotionConnectionDb"));
});



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
