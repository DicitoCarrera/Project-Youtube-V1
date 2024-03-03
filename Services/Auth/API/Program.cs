using API;
using API.Endpoints;
using Application;
using Infrastructure;

var builder = WebApplication.CreateBuilder(args: args);
{
    // Add services to the container.
    builder.Services
        .AddApplication()
        .AddInfrastructure()
        .AddApi();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapAuthEndpoints();

    app.Run();
}