using System;
using System.IO;
using Google.Cloud.Vision.V1;

namespace BulkImageRecognition
{
    class BulkImageRecog
    {
        public void Run()
        {
            string IMAGE_PATH = "src/images/";

            // Instantiates a client
            var client = ImageAnnotatorClient.Create();

            foreach (string file in Directory.EnumerateFiles(IMAGE_PATH, "*.jpg"))
            {
                // Load the image file into memory
                var image = Image.FromFile(file);

                // Performs label detection on the image file
                var response = client.DetectLabels(image);
                string imageLabels = "";
                string labelTextFile;
                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                    {
                        Console.WriteLine(annotation.Description);

                        // store all labels
                        imageLabels = imageLabels + annotation.Description + ",";
                    }
                }
                // create a text file for each image with corresponding labels
                labelTextFile = IMAGE_PATH + Path.GetFileName(file) + "-labels.txt";
                File.WriteAllText(labelTextFile, imageLabels);
            }

            // pause the cmd window from closing
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
      
    }
}
