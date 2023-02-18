using System.Reflection;
using Ilum.Api.Context;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IlumContext>(); // DbContext

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddMediatR(Assembly.GetEntryAssembly()); // MediatR
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // AutoMapper

builder.Services.AddScoped<IIlumContext>(provider => provider.GetService<IlumContext>());

builder.Services.AddSwaggerGen(); // Swagger

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
