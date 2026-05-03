using System.Text;

string folderPath = "sales";
string outputFile = "report.txt";

GenerateSalesSummary(folderPath, outputFile);

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

    // Build report
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