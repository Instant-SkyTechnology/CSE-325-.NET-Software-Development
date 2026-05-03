# Build .NET Applications with C# Assignment

## Overview
This project contains:
- ASP.NET Core Web API (Pizza API)
- Console application (Sales Summary Report)

---

## Part 1: Web API (Pizza API)

Built using .NET 8 and ASP.NET Core Minimal API.

### Sample Response: GET /pizza

**Status Code: HTTP/1.1 200 OK**

```json
[
  {
    "id": 1,
    "name": "Classic Italian",
    "isGlutenFree": false
  },
  {
    "id": 2,
    "name": "Veggie",
    "isGlutenFree": true
  },
  {
    "id": 3,
    "name": "Meat Lovers",
    "isGlutenFree": false
  },
  {
    "id": 4,
    "name": "BBQ Chicken",
    "isGlutenFree": false
  }
]
```

### Sample Response: POST /pizza

Creates a new pizza.

**Status Code: HTTP/1.1 201 Created**  
**Location:** /pizza/5

```json
{
  "id": 5,
  "name": "Hawaiian",
  "isGlutenFree": false
}
```

### Sample Response: PUT /pizza/{id}

Updates an existing pizza.

**Status Code: HTTP/1.1 204 No Content**


### Sample Response: DELETE /pizza/{id}

Deletes a pizza.

**Status Code: HTTP/1.1 204 No Content**


---

## Part 2: Sales Summary Function

This function reads all `.txt` files in a specified directory, calculates total sales per file, and generates a formatted summary report.

```csharp
static void GenerateSalesSummary(string directoryPath, string outputFile)
{
    var files = Directory.GetFiles(directoryPath, "*.txt");
    var report = new StringBuilder();

    decimal totalSales = 0;
    var fileTotals = new Dictionary<string, decimal>();

    foreach (var file in files)
    {
        decimal fileTotal = 0;

        foreach (var line in File.ReadAllLines(file))
        {
            if (decimal.TryParse(line, out decimal value))
            {
                fileTotal += value;
            }
        }

        fileTotals[file] = fileTotal;
        totalSales += fileTotal;
    }

    report.AppendLine("Sales Summary");
    report.AppendLine("----------------------------");
    report.AppendLine($"Total Sales: {totalSales:C}");
    report.AppendLine();
    report.AppendLine("Details:");

    foreach (var entry in fileTotals)
    {
        var fileName = Path.GetFileName(entry.Key);
        report.AppendLine($"{fileName}: {entry.Value:C}");
    }

    File.WriteAllText(outputFile, report.ToString());
}
```