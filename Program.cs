using api.Services;   
using api.Models;
using api.db;
using Microsoft.EntityFrameworkCore;    

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Service>();

builder.Services.AddDbContext<StockDb>(options =>  
    options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<crudService>();   

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StockDb>();
    db.Database.EnsureCreated();
}

app.MapGet("/hello", (Service service) =>
{
    return service.GetMessage(); //Call a function that belongs to a class.
});



app.MapPost("/stocks", async (crudService service, Stock stock) =>   
{
    return await service.CreateAsync(stock);
});


app.MapGet("/stocks", async (crudService service) =>
{
    return await service.GetAllAsync();
});

app.Run();