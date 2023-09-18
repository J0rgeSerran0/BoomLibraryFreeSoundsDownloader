using BoomLibraryFreeSoundsDownloader.Application.Services;
using System.Configuration;

try
{
    Console.WriteLine();
    Console.BackgroundColor = ConsoleColor.Cyan;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine($" {new String('*', nameof(BoomLibraryFreeSoundsDownloader).Length + 4)} ");
    Console.WriteLine($" * {nameof(BoomLibraryFreeSoundsDownloader)} * ");
    Console.WriteLine($" {new String('*', nameof(BoomLibraryFreeSoundsDownloader).Length + 4)} ");
    Console.ResetColor();
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine(" Reading settings... ");
    Console.ResetColor();

    Console.ForegroundColor = ConsoleColor.Cyan;
    var configDestinyPath = ConfigurationManager.AppSettings["DestinyPath"];
    var configHtmlContentPath = ConfigurationManager.AppSettings["HtmlContentPath"];
    bool configOverwriteSounds = Convert.ToBoolean(ConfigurationManager.AppSettings["OverwriteSounds"]);

    Console.Write($"\tDestiny path: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"'{configDestinyPath}'");
    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.Write($"\tHtml Content path: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"'{configHtmlContentPath}'");
    Console.ForegroundColor = ConsoleColor.Cyan;

    //var overwriteSounds = true;
    //if (configOverwriteSounds == "0")
    //    overwriteSounds = false;

    Console.Write($"\tOverwrite Sounds: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"'{configOverwriteSounds}'");
    Console.ForegroundColor = ConsoleColor.Cyan;

    Console.ResetColor();
    Console.WriteLine();

    if (String.IsNullOrWhiteSpace(configHtmlContentPath))
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

            var htmlContent = File.ReadAllText(configHtmlContentPath).Trim();

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
                var boomLibraryService = new BoomLibraryService(configDestinyPath, htmlContent, configOverwriteSounds);
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

// Process Finished!
Console.BackgroundColor = ConsoleColor.Yellow;
Console.ForegroundColor = ConsoleColor.Black;
Console.Write(" The process has finished! ");
Console.ResetColor();
Console.WriteLine();
