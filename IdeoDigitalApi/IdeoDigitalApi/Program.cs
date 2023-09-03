using IdeoDigitalApi.Data;
using IdeoDigitalApi.Data.Interfaces;
using IdeoDigitalApi.Data.Repositories;
using IdeoDigitalApi.Services;
using IdeoDigitalApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("InMem"));
builder.Services.AddCors(x => x.AddDefaultPolicy(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IItemRepository, ItemsRepository>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IInvoiceItemsRepository, InvoicesItemsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IdeoDigital v1"));
}

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

app.Run();
