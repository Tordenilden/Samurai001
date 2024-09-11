using Samurai001.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Samurai001.Repository.Interfaces;
using Samurai001.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

////////////////////////////////////////////////////////////////////
builder.Services.AddScoped<IGeneric<Horse>, GenericRepo<Horse>>();

///////////////////////////////////////////////////////////////////


builder.Services.AddScoped<IRepository<Samurai>, GenericRepository<Samurai>>();
builder.Services.AddScoped<IRepository<Battle>, GenericRepository<Battle>>();
builder.Services.AddScoped<IRepository<Horse>, GenericRepository<Horse>>();

string conStr = @"Server=TEC-8220-LA0025;Database=Samurai002; Trusted_Connection=true; Trust Server Certificate=true; Integrated Security=true; Encrypt=True; ";
//string conStr = "Data Source=TEC-8220-LA0025;Initial Catalog=Samurai001;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True; Trusted_Connection=true;";
builder.Services.AddDbContext<DatabaseContext>(obj => obj.UseSqlServer(conStr));

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
