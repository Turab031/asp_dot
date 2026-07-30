using Microsoft.EntityFrameworkCore;
using pro2.Data;
using pro2.IService;
using pro2.Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddScoped<IAuthService,AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.MapGet("/weatherforecast", () =>
// {
//     return new[]
//     {
//         new
//         {
//             Date = DateOnly.FromDateTime(DateTime.Now),
//             TemperatureC = 25,
//             Summary = "Sunny"
//         }
//     };
// });

app.MapControllers();
app.Run();