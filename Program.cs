using Microsoft.EntityFrameworkCore;
using TheKeySystem.Models;
using TheKeySystem.Repositories;
using TheKeySystem.Repositories.Interfaces;
using TheKeySystem.Services;
using TheKeySystem.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<TksDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("TksDefaultConnection")));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddRouting(options =>
{
    options.ConstraintMap.Add("id", typeof(long));
});

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
