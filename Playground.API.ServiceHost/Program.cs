using Microsoft.EntityFrameworkCore;
using Playground.API.Core.Application.Interfaces;
using Playground.API.Core.Application.Services;
using Playground.API.Core.Infrastructure;
using Playground.API.Core.Infrastructure.SqlDatabase;

var builder = WebApplication.CreateBuilder(args);

// SQL database
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetValue<string>("NEON_DB_CONNECTION_STRING")));

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Application service.
builder.Services.AddScoped<IGymTrainingRecommendationService, GymTrainingRecommendationService>();
builder.Services.AddScoped<IPassportService, PassportService>();
builder.Services.AddScoped<ILlmFacade, LlmFacade>();
builder.Services.AddScoped<IDataRoomService, DataRoomService>();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();