using BoomLibraryFreeSoundsDownloader.Application.Models;
using BoomLibraryFreeSoundsDownloader.Application.Validators;
using HtmlAgilityPack;

namespace BoomLibraryFreeSoundsDownloader.Application.Services
{
    public class BoomLibraryService
    {
        private string _destinyPath = String.Empty;
        private string _htmlContent = String.Empty;
        private bool _overwriteSounds = true;

        public BoomLibraryService(string destinyPath, string htmlContent, bool overwriteSounds)
        {
            _destinyPath = destinyPath.Trim().TrimEnd('\\') + @"\";            

            BoomLibraryValidator.ValidateDestinyPath(_destinyPath);

            _htmlContent = htmlContent.Trim();
            
            _overwriteSounds = overwriteSounds;
        }

        private void GetWaveFile(FreeSoundModel freeSound)
        {
            using (Stream ms = File.Create($"{_destinyPath}{freeSound.Name}"))
            using (HttpClient client = new HttpClient())
                client.GetStreamAsync(freeSound.Download).Result.CopyTo(ms);
        }

        public void GetContent()
        {
            var freeSounds = new List<FreeSoundModel>();

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(_htmlContent);


            var table = htmlDocument.DocumentNode.SelectSingleNode("//table");
            var tableRows = table.SelectNodes("tr");
            var columns = tableRows[0].SelectNodes("th/text()");
            for (int i = 1; i < tableRows.Count; i++)
            {
                var fileName = tableRows[i].SelectSingleNode("td[1]").InnerText;
                var partialUrl = tableRows[i].SelectSingleNode("td[2]/button").Attributes["onclick"].Value;

                if (partialUrl != null)
                {
                    partialUrl = partialUrl.Replace("window.open('", "");
                    partialUrl = partialUrl.Substring(0, partialUrl.Length - 2);
                }

                // Add to the collection
                freeSounds.Add(new FreeSoundModel(fileName, new Uri($"https://www.boomlibrary.com{partialUrl}")));
            }

            // Information for the user
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($" Number of Free Sounds found: {freeSounds.Count} ");
            Console.WriteLine();
            Console.ResetColor();

            // Extract and Save each Free Sound File
            var index = 1;

            Console.Write($"\t");
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($" Extracting... ");
            Console.ResetColor();

            foreach (var freeSound in freeSounds)
            {
                // Information for the user
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"\tFile {index} of {freeSounds.Count} - ");

                if (!File.Exists($"{_destinyPath}{freeSound.Name}") || _overwriteSounds)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"'{freeSound.Name}'");
                    Console.ResetColor();

                    GetWaveFile(freeSound);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"'{freeSound.Name}'");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($" not downloaded because it exists");
                    Console.ResetColor();
                }

                index += 1;
            }
            Console.WriteLine();
            Console.ResetColor();
        }
    }
}
