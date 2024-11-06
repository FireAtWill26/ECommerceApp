using Microsoft.EntityFrameworkCore;
using ReviewMicroservice.ApplicationCore.Contracts.Repositories;
using ReviewMicroservice.ApplicationCore.Contracts.Services;
using ReviewMicroservice.Infrastructure.Data;
using ReviewMicroservice.Infrastructure.Repositories;
using ReviewMicroservice.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddScoped<IReviewRepositoryAsync, ReviewRepositoryAsync>();
builder.Services.AddScoped<IReviewServiceAsync, ReviewServiceAsync>();

//builder.Services.AddDbContext<ECommerceDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));
//});

builder.Services.AddDbContext<ECommerceDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("ReviewConnectionDb"));
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
