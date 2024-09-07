using Playground.API.Core.Application.Interfaces;
using Playground.API.Core.Application.Services;
using Playground.API.Core.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILlmFacade, LlmFacade>();
builder.Services.AddSingleton<IGymTrainingRecommendationService, GymTrainingRecommendationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();