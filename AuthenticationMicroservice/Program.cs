using AuthenticationMicroservice.Data;
using AuthenticationMicroservice.Model;
using AuthenticationMicroservice.Repository;
using JwtAuthenticationManager;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<JwtTokenHandler>();

builder.Services.AddScoped<IAccountRepository, AccountRepository>();

//builder.Services.AddDbContext<AuthenticationDbContext>(option =>
//{
//    option.UseSqlServer(builder.Configuration.GetConnectionString("ECommerceDb"));
//});

builder.Services.AddDbContext<AuthenticationDbContext>(option =>
{
    option.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationConnectionDb"));
});


builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthenticationDbContext>();

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
