using AustinReview.MongoDemo.Context;
using AustinReview.MongoDemo.Help;
using AustinReview.MongoDemo.Interface;
using AustinReview.MongoDemo.Interface.impl;
using AustinReview.MongoDemo.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IMongoConnection, MongoConnection>();
builder.Services.AddScoped<IMongoContext, MongoContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMongoRepository<object>, MongoBaseRepository<object>>();
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