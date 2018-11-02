using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace SetDateTakenOnAndroidBurstPhotos
{
    class Program
    {
        static void Main(string[] args)
        {
            var targetDir = Environment.CurrentDirectory;
            if (args.Length > 0)
            {
                targetDir = args[0];
            }

            var photos = GetBurstPhotoPaths(targetDir);

            UpdatePhotoDateTaken(photos);
        }

        private static void UpdatePhotoDateTaken(IEnumerable<string> photos)
        {
            foreach (var photoFilePath in photos)
            {
                using (Bitmap bmp = new Bitmap(photoFilePath))
                {
                    var dateTaken = bmp.GetPropertyItem(256);

                    Console.WriteLine(Encoding.Default.GetString(dateTaken.Value));
                }
            }
        }

        private static IEnumerable<string> GetBurstPhotoPaths(string targetDir)
        {
            return Directory.EnumerateFiles(targetDir, @"*_BURST*.jpg", new EnumerationOptions { MatchCasing = MatchCasing.CaseInsensitive, RecurseSubdirectories = true });
        }
    }
}
