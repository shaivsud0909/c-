using api.Services;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Service>();

// 🔴 ADD Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔴 Enable Swagger UI
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.MapGet("/hello", (Service service) =>
{
    return service.GetMessage();
});

app.Run();

