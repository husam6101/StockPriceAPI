using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockPriceAPI.Data;
using StockPriceAPI.Implementations;
using StockPriceAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BitcoinPriceContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("BitcoinPriceDatabase")));

builder.Services.AddScoped<BitcoinPriceFetcherFactory>();
builder.Services.AddScoped<BitcoinPriceService>();
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

app.Run();
