using Microsoft.EntityFrameworkCore;
using ProjectZurich.API;
using ProjectZurich.Application.Services;
using ProjectZurich.Domain.Repositories;
using ProjectZurich.Domain.Services;
using ProjectZurich.Infrastructure;
using ProjectZurich.Infrastructure.Repositories;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .WithOrigins("*")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZurichSQLServerConnection"));
});

builder.Services.AddScoped<IVeiculoRepository, VeiculoRepository>();
builder.Services.AddScoped<ISeguradoRepository, SeguradoRepository>();
builder.Services.AddScoped<ISeguroRepository, SeguroRepository>();
builder.Services.AddScoped<ISeguroService, SeguroService>();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
