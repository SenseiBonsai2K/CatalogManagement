using Application.Services;
using CatalogManagement.Models.Repositories;
using MenuManager.Models.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add DBContext
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add repositories
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<ApparelRepository>();
builder.Services.AddScoped<CategoryRepository>();

// Add services
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ApparelService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
