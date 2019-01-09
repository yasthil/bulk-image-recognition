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
                foreach (var annotation in response)
                {
                    if (annotation.Description != null)
                    {
                        // print out the Description of the image from the response we get from Google Cloud Vision's API
                        Console.WriteLine(annotation.Description);
                    }
                }               
            }

            // pause the cmd window from closing
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
      
    }
}
