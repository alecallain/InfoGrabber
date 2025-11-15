using InfoGrabber.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors();

// builder.Services.AddDbContextFactory<InfoContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("Database")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/{id:int}", (int id) =>
    {

    })
    .WithName("Retrieve")
    .WithOpenApi();

app.MapPost("/insert", () =>
    {
        
    })
    .WithName("InsertData")
    .WithOpenApi();

app.Run();