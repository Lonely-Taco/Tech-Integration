using TechIntegration.Client.Client;
using TechIntegration.Core.Parser;
using TechIntegration.Core.Services;
using TechIntegration.Infra.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IClient, Client>();
builder.Services.AddScoped<ICsvParse, Parser>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddControllers();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapControllers();

app.UseHttpsRedirection();


app.Run();