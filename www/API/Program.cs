using JsonPlaceholder.Service.Extensions;
using JsonPlaceholder.Service.Services.Posts;
using JsonPlaceholder.Service.Services.Posts.Models;
using TMDB.Service.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//  Add services to the container.
builder.Services
    .AddJsonPlaceholderService()
    .AddConfigurationJsonPlaceholder(option => { option.URL = "https://jsonplaceholder.typicode.com"; })
    ;

builder.Services
    .AddConfigurationTmdb(option =>
    {
        option.URL = "";
        option.APIKey = "";
        option.APIVersion = "";
    })
    .AddTmdbService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/post", (int id) =>
    {
        // Get service from DI
        var jsonPlaceholderPostService = app.Services.GetRequiredService<IJsonPlaceholderPostService>();

        // Call service method
        var result = jsonPlaceholderPostService.GetAsync(new JsonPlaceholderPostRequest
        {
            Id = id
        });
        // Return result
        return result;
    })
    .WithOpenApi();

app.MapPost("/post", () =>
    {
        // Get service from DI
        var jsonPlaceholderPostService = app.Services.GetRequiredService<IJsonPlaceholderPostService>();

        // Call service method
        var result = jsonPlaceholderPostService.PostAsync(new JsonPlaceholderPostPostRequest
        {
            Title = "Test",
            Body = "Test",
            UserId = 1
        });

        // Return result
        return result;
    })
    .WithOpenApi();

app.Run();