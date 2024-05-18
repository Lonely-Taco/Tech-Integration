using TechIntegration.Client.Client;
using TechIntegration.Core.Parser;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IClient, Client>();
builder.Services.AddSingleton<ICsvParse, Parser>();
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
