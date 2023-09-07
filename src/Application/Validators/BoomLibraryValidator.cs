namespace BoomLibraryFreeSoundsDownloader.Application.Validators
{
    public static class BoomLibraryValidator
    {
        public static void ValidateDestinyPath(string destinyPath)
        {
            if (String.IsNullOrWhiteSpace(destinyPath))
                throw new ArgumentNullException(nameof(destinyPath));

            if (!Directory.Exists(destinyPath))
                Directory.CreateDirectory(destinyPath);
        }
    }
}