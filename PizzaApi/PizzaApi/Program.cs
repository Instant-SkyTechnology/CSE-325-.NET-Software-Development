using PizzaApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// PIZZAS LIST RIGHT HERE
var pizzas = new List<Pizza>
{
    new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
    new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true },
    new Pizza { Id = 3, Name = "Meat Lovers", IsGlutenFree = false },
    new Pizza { Id = 4, Name = "BBQ Chicken", IsGlutenFree = false } 
};

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");

app.MapGet("/pizza", () => pizzas);

app.MapGet("/pizza/{id}", (int id) =>
{
    var pizza = pizzas.FirstOrDefault(p => p.Id == id);
    return pizza is not null ? Results.Ok(pizza) : Results.NotFound();
});

app.MapPost("/pizza", (Pizza pizza) =>
{
    pizza.Id = pizzas.Max(p => p.Id) + 1;
    pizzas.Add(pizza);
    return Results.Created($"/pizza/{pizza.Id}", pizza);
});

app.MapPut("/pizza/{id}", (int id, Pizza updated) =>
{
    var pizza = pizzas.FirstOrDefault(p => p.Id == id);
    if (pizza is null) return Results.NotFound();

    pizza.Name = updated.Name;
    pizza.IsGlutenFree = updated.IsGlutenFree;

    return Results.NoContent();
});

app.MapDelete("/pizza/{id}", (int id) =>
{
    var pizza = pizzas.FirstOrDefault(p => p.Id == id);
    if (pizza is null) return Results.NotFound();

    pizzas.Remove(pizza);
    return Results.NoContent();
});

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
