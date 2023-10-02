using System;
using System.IO;
using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        if(args.Length < 2)
        {
            Console.WriteLine("Usage: cliZIP.exe <sourceFilePath> <destinationZipPath>");
            return;
        }

        string sourceFile = args[0];
        string destinationZip = args[1];

        if(!File.Exists(sourceFile))
        {
            Console.WriteLine($"Error: File '{sourceFile}' does not exist.");
            return;
        }

        try
        {
            // Compress the file
            using (FileStream zipToOpen = new FileStream(destinationZip, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(sourceFile, Path.GetFileName(sourceFile));
                }
            }

            Console.WriteLine($"File '{sourceFile}' compressed to '{destinationZip}' successfully!");
        }
        catch(Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
