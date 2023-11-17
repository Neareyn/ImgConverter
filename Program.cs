using System;
using System.IO;
using ImageMagick;

public class DdsToPngConverter
{
    public static void Main()
    {
        // Define the input and output formats
        string inputFormat = "*.dds"; // File format to search for in the input folder
        string outputFormat = ".png"; // Output file format

        // Define source and destination folders
        string sourceFolder = "F:\\Input"; // Enter Input Folder
        string destinationFolder = "F:\\Output"; // Enter Output Folder

        // Get a list of image files with the specified input format in the source folder
        string[] imageFiles = Directory.GetFiles(sourceFolder, inputFormat);

        // Loop through each image file and convert it to the Output Format
        foreach (string imageFile in imageFiles)
        {
            try
            {
                // Load the image using ImageMagick
                using (MagickImage image = new MagickImage(imageFile))
                {
                    // Create an output filename based on the original image filename and desired output filetype
                    string pngFileName = Path.GetFileNameWithoutExtension(imageFile) + outputFormat;

                    // Combine the destination folder path with the new filename to get the full output path
                    string destinationPath = Path.Combine(destinationFolder, pngFileName);

                    // Convert and save the image in PNG format
                    image.Write(destinationPath);
                }
            }
            catch (MagickCoderErrorException ex)
            {
                // Handle ImageMagick-specific conversion errors
                Console.WriteLine($"Error while converting {imageFile} to {outputFormat}: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Handle other unexpected errors
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
