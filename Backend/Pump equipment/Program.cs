using Microsoft.EntityFrameworkCore;
using Pump_equipment.Data.Context;
using Pump_equipment.Data.Repositories;
using Pump_equipment.DataExtetion;
using Pump_equipment.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PumpDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddScoped<PumpService>();
builder.Services.AddScoped<PumpRepository>();
builder.Services.AddScoped<MotorService>();
builder.Services.AddScoped<MotorRepository>();
builder.Services.AddScoped<MaterialService>();
builder.Services.AddScoped<MaterialRepository>();


var app = builder.Build();


app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MigrateDatabase();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
});

app.Run();
