var today = DateTime.Now;
var christmas = new DateTime(today.Year, 12, 25);

// String interpolation:
Console.WriteLine("Hello, World!");
Console.WriteLine($"The current time is {today}");

// Calculate days until next Christmas

// If Christmas already passed this year, use next year's date
if (today > christmas)
{
    christmas = new DateTime(today.Year + 1, 12, 25);
}

var daysUntilChristmas = (christmas - today).Days;

Console.WriteLine($"There are {daysUntilChristmas} days until the next Christmas.");

