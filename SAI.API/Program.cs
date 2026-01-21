using Microsoft.EntityFrameworkCore;
using SAI.Core.Interfaces.Repositories;
using SAI.Core.Interfaces.Services;
using SAI.Infrastructure.Persistence;
using SAI.Infrastructure.Repositories;
using SAI.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Connection")));

// Start Repository
builder.Services.AddScoped<ISearchAttributeRepository, SearchAttributeRepository>();

// End Repository

// Start Services
builder.Services.AddScoped<ISearchAttributeService, SearchAttributeService>();
// End Services

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();