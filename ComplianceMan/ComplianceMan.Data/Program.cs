using ComplianceMan.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContextFactory<ComplianceManDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//builder.Services.AddDbContext<ComplianceManDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

//builder.Services.AddScoped(sp =>
//{
//    var factory = sp.GetRequiredService<IDbContextFactory<ComplianceManDbContext>>();
//    return factory.CreateDbContext();
//});

//builder.Services.AddScoped<IDatabaseRepository, DatabaseRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
