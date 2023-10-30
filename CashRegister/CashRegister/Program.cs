using CashRegister.Models;
using CashRegister.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<RebarDatabaseSettings>(
    builder.Configuration.GetSection(nameof(RebarDatabaseSettings)));

builder.Services.AddSingleton<IRebarDatabaseSettings>(sp =>
    sp.GetRequiredService<IOptions<RebarDatabaseSettings>>().Value);

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetValue<string>("RebarDatabaseSettings:ConnecionString")));

builder.Services.AddScoped<IShakeService, ShakeService>();

builder.Services.AddControllers();
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
