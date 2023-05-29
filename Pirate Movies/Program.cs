using Microsoft.EntityFrameworkCore;
using Pirate_Movies;
using Pirate_Movies.Data;
using System;
using Microsoft.Extensions.DependencyInjection;
using Pirate_Movies.Interfaces;
using Pirate_Movies.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//builder.Services.AddScoped<ICountryRepository, CountryRepository>();
//builder.Services.AddScoped<IEpisodeRepository, EpisodeRepository>();
//builder.Services.AddScoped<ILinkRepository, LinkRepository>();
//builder.Services.AddScoped<IMovieRepository, MovieRepository>();
//builder.Services.AddScoped<IShowRepository, ShowRepository>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Data"));
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

using (var scope = app.Services.CreateScope())
{
    Seed.Initialize(scope.ServiceProvider);
}

app.Run();
