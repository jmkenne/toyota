using System;
using System.Drawing;

namespace VerticalLineCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if the correct number of arguments is provided
            if (args.Length != 1)
            {
                Console.WriteLine("Usage: VerticalLineCounter <image_path>");
                return;
            }

            // Handling errors
            string imagePath = args[0];
            int verticalLines = CountVerticalLines(imagePath);

            if (verticalLines >= 0)
                Console.WriteLine($"Number of vertical lines in {imagePath}: {verticalLines}");
            else
                Console.WriteLine($"Error: {verticalLines}");
        }

        // Function to count vertical lines in the image
        static int CountVerticalLines(string imagePath)
        {
            try
            {
                // Load the image from the provided path
                Bitmap image = new Bitmap(imagePath);

                int width = image.Width;
                int height = image.Height;
                int verticalLines = 0;

                // Check each column for vertical lines
                for (int x = 0; x < width; x++)
                {
                    bool isLine = false;
                    for (int y = 0; y < height; y++)
                    {
                        Color pixelColor = image.GetPixel(x, y);
                        if (pixelColor.R == 0 && pixelColor.G == 0 && pixelColor.B == 0) // Black pixel
                        {
                            isLine = true;
                            break;
                        }
                    }
                    if (isLine)
                        verticalLines++;
                }

                return verticalLines;
            }
            catch (Exception e)
            {
                return -1; // Error occurred
            }
        }
    }
}
