using System.Reflection;
using System.Text;
using Ilum.Api.Configurations;
using Ilum.Domain.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ConfigurationManager = Ilum.Api.Configurations.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContextServices();
builder.Services.AddMediatRServices();
builder.Services.AddAutoMapperServices();
builder.Services.AddSwaggerServices();
builder.Services.AddAutoMapperServices();
builder.Services.AddScoped<IIlumContext>(provider => provider.GetService<IlumContext>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "Ilum");
    });
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
app.Run();