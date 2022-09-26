using LibraryMicroservice.Gateways;
using LibraryMicroservice.Repositories;
using LibraryMicroservice.Services;
using LibraryMicroservice.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

//Repositories
builder.Services.AddSingleton<IUsersRepository, UsersRepository>();
builder.Services.AddSingleton<IAlbumsRepository, AlbumsRepository>();

//Services
builder.Services.AddScoped<IAlbumService, AlbumService>();
builder.Services.AddScoped<IUserService, UserService>();

//API Gateways
builder.Services.AddScoped<IAPIGateway, SpotifyGateway>();


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
