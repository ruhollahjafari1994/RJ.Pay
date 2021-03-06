using Microsoft.EntityFrameworkCore;
using RJ.Pay.Data.DatabaseContext;
using RJ.Pay.Repo;
using RJ.Pay.Services.Site.Admin.Auth.Interface;
using RJ.Pay.Services.Site.Admin.Auth.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUnitOfWork<RJDbContext>, UnitOfWork<RJDbContext>>();
builder.Services.AddScoped<IAuthService, AuthService>();
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
