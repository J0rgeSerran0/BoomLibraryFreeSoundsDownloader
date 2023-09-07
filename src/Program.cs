using BoomLibraryFreeSoundsDownloader.Application.Services;
using System.Configuration;

Console.WriteLine();
Console.BackgroundColor = ConsoleColor.Cyan;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine($" {new String(' ', nameof(BoomLibraryFreeSoundsDownloader).Length)} ");
Console.WriteLine($" {nameof(BoomLibraryFreeSoundsDownloader)} ");
Console.WriteLine($" {new String(' ', nameof(BoomLibraryFreeSoundsDownloader).Length)} ");
Console.ResetColor();
Console.WriteLine();

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(" Reading settings... ");
Console.ResetColor();

Console.ForegroundColor = ConsoleColor.Cyan;
var destinyPath = ConfigurationSettings.AppSettings["DestinyPath"];
var htmlContentPath = ConfigurationSettings.AppSettings["HtmlContentPath"];

Console.Write($"\tDestiny path: ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"'{destinyPath}'");
Console.ForegroundColor = ConsoleColor.Cyan;

Console.Write($"\tHtml Content path: ");
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine($"'{htmlContentPath}'");
Console.ForegroundColor = ConsoleColor.Cyan;

Console.ResetColor();
Console.WriteLine();

if (String.IsNullOrWhiteSpace(htmlContentPath))
{
    // VALIDATION ERROR > Html Content Path Value is empty
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(" Html Content path is empty ");
    Console.ResetColor();
    Console.WriteLine();
}
else
{
    try
    {
        // Reading Html Content
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" Reading Html Content... ");
        Console.ResetColor();

        var htmlContent = File.ReadAllText(htmlContentPath).Trim();

        if (String.IsNullOrWhiteSpace(htmlContent))
        {
            // VALIDATION ERROR > Html Content does not exist
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Html Content is empty ");
            Console.ResetColor();
            Console.WriteLine();
        }
        else
        {
            // Html Content Loaded!
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\tHtml Content Loaded!");
            Console.WriteLine();
            Console.ResetColor();

            // Run the Service
            var boomLibraryService = new BoomLibraryService(destinyPath, htmlContent);
            boomLibraryService.GetContent();
        }
    }
    catch (Exception ex)
    {
        // ERROR
        Console.BackgroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($" ERROR: {ex.Message} ");
        Console.ResetColor();
        Console.WriteLine();
    }
}

// Process Finished!
Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.WriteLine(" The process has finished! ");
Console.ResetColor();
Console.WriteLine();
