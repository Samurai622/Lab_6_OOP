using System;
using System.IO;
using System.Text.RegularExpressions;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace Lab_6_OOP
{
    public static class Task2
    {
        public static void Run()
        {
            string directoryPath = Directory.GetCurrentDirectory();
            string[] imageFiles = Directory.GetFiles(directoryPath);

            Regex regex = new Regex(@"\.(bmp|gif|tiff?|jpe?g|png)$", RegexOptions.IgnoreCase);

            foreach (string file in imageFiles)
            {
                string fileName = Path.GetFileName(file);

                try
                {
                    using Image image = Image.Load(file);
                    {
                        image.Mutate(x => x.Flip(FlipMode.Vertical));

                        string nameOnly = Path.GetFileNameWithoutExtension(fileName);
                        string newName = Path.Combine(directoryPath, nameOnly + "-mirrored.gif");

                        image.SaveAsGif(newName);
                        Console.WriteLine($"Оброблено зображення: {fileName} -> {newName}");
                    }
                }
                catch(Exception)
                {
                    try
                    {
                        string ext = Path.GetExtension(fileName);

                        if(regex.IsMatch(ext))
                        {
                            Console.WriteLine($"Не вдалося обробити зображення: {fileName}");
                        }
                    }
                    catch {}
                }
            }
        }
    }
}