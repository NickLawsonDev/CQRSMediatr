using System.Reflection;
using CQRSMediatr.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbApplicationContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(DbApplicationContext).Assembly.FullName)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();