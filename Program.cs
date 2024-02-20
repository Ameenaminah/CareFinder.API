using Serilog;
using CareFinder.API.Data;
using System.Text;
using Microsoft.EntityFrameworkCore;
using CareFinder.API.Configurations;
using CareFinder.API.Interfaces;
using CareFinder.API;
using CareFinder.API.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddDbContext<CareFinderDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CareFinderDbConnectionString")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
        b.AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()
    );
});
builder.Host.UseSerilog((context, logger) => logger.WriteTo.Console().ReadFrom.Configuration(context.Configuration));

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IHospitalsRepository, HospitalsRepository>();
builder.Services.AddScoped<IAddressesRepository, AddressesRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseCors("AllowAll");
app.UseRouting();

app.MapControllers();

app.Run();


