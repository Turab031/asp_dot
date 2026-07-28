var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

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