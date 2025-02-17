namespace designpatterns.dp;

using System;
using System.Collections.Generic;

// 1. Target Interface (New Reporting System expects this)
public interface INewReportGenerator
{
    List<string> GenerateSalesReport(DateTime startDate, DateTime endDate);
}

// 2. Adaptee (Legacy Reporting System with an incompatible interface)
public class LegacyReportGenerator
{
    public string CreateReport(DateTime start, DateTime end) // Different method signature
    {
        // Simulate legacy reporting logic
        return $"Legacy Report from {start:yyyy-MM-dd} to {end:yyyy-MM-dd} (Legacy Format)";
    }
}

// 3. Adapter (Bridges INewReportGenerator to LegacyReportGenerator)
public class LegacyReportAdapter : INewReportGenerator
{
    private LegacyReportGenerator _legacyGenerator;

    public LegacyReportAdapter(LegacyReportGenerator legacyGenerator)
    {
        _legacyGenerator = legacyGenerator;
    }

    public List<string> GenerateSalesReport(DateTime startDate, DateTime endDate)
    {
        Console.WriteLine("Adapter: Converting new report request to legacy format...");
        string legacyReportData = _legacyGenerator.CreateReport(startDate, endDate);

        // Adapt the legacy format to the new system's expected format (List<string>)
        // Here, we're just splitting the legacy report string into a list of lines, for simplicity.
        // In a real scenario, you might need more complex parsing and transformation.
        List<string> salesReportLines = new List<string>();
        salesReportLines.Add("--- Sales Report ---");
        salesReportLines.Add(legacyReportData);
        salesReportLines.Add("--- End of Report ---");

        Console.WriteLine("Adapter: Legacy report data adapted to new format.");
        return salesReportLines;
    }
}

// 4. Client (New Reporting Application)
public class NewReportingApplication
{
    private INewReportGenerator _reportGenerator;

    public NewReportingApplication(INewReportGenerator reportGenerator)
    {
        _reportGenerator = reportGenerator;
    }

    public void DisplaySalesReport(DateTime start, DateTime end)
    {
        Console.WriteLine("New Reporting Application: Generating Sales Report...");
        List<string> reportData = _reportGenerator.GenerateSalesReport(start, end);

        Console.WriteLine("\n--- Sales Report ---");
        foreach (string line in reportData)
        {
            Console.WriteLine(line);
        }
        Console.WriteLine("--- End of Sales Report ---");
    }
}