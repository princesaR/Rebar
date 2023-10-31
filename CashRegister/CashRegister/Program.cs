using CashRegister.Data;
using CashRegister.Models;
using CashRegister.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Register services here
builder.Services.Configure<RebarDatabaseSettings>(builder.Configuration.GetSection(nameof(RebarDatabaseSettings)));

builder.Services.AddSingleton<MongodbRebarContext>(serviceProvider =>
{
    var settings = serviceProvider.GetRequiredService<IOptions<RebarDatabaseSettings>>().Value;
    return new MongodbRebarContext(settings.ConnectionString.ToString(), settings.DatabaseName.ToString());
});

builder.Services.AddScoped<IShakeService, ShakeService>();
builder.Services.AddScoped<IOrderService, OrderService> ();
builder.Services.AddScoped<IAccuntService, AccuntService>();


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
