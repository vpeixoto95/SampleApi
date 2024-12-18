using Microsoft.EntityFrameworkCore;
using SampleApi.Data;
using SampleApi.Data.Entities;
using SampleApi.Data.Interfaces;
using SampleApi.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IRecordsRepository, RecordsRepository>();
builder.Services.AddDbContextFactory<SampleApiDbContext>(options => options.UseInMemoryDatabase(nameof(Record)));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
