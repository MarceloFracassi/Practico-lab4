
using Microsoft.EntityFrameworkCore;
using Tp_lab4.Service;
using Practico_labIV.dbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContextPractico>(dbContextOptions => dbContextOptions.UseSqlite(builder.Configuration["DB:ConnectionString: "]));

builder.Services.AddScoped<UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
