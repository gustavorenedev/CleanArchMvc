using CleanArchMvc.Infra.IoC;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStatusCodePages();

app.UseAuthorization();

app.MapControllers();

app.Run();
