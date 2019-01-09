using System;
using System.IO;
using Google.Cloud.Vision.V1;

namespace BulkImageRecognition
{
    class BulkImageRecog
    {
        public void Run()
        {
            // Load an image from a local file.
            var filePath = "/PATH/TO/IMAGE.png";
            var image = Image.FromFile(filePath);
            var client = ImageAnnotatorClient.Create();
            var response = client.DetectLabels(image);
            foreach (var annotation in response)
            {
                if (annotation.Description != null)
                    Console.WriteLine(annotation.Description);
            }
        }
      
    }
}
