using DemoApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.MapGet("/temperatures/farenheit/{temp:float}/celcius", (float temp) =>
{
    var result = TemperatureConverter.ConvertFromF(temp);
    return new ConversionResponse(temp, result);
});

app.MapGet("/temperatures/celcius/{temp:float}/farenheit", (float temp) =>
{
    var result = TemperatureConverter.ConvertFromC(temp);
    return new ConversionResponse(temp, result);
});

app.Run(); // "Blocking Call"

public record ConversionResponse(float F, float C);