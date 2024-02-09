using AEMOContracts;
using AEMORepository;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMatchContract, MatchRepository>();
builder.Services.AddScoped<IFindStartContract, FindStartRepository>();
builder.Services.AddScoped<IMatchRContract, MatchR>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSwagger();
app.UseSwaggerUI(s =>
{
    s.SwaggerEndpoint("/swagger/v1/swagger.json", "AEMO");
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
