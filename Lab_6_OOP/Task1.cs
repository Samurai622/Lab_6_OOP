using System;
using System.IO;
using System.Linq;

namespace Lab_6_OOP
{
    public static class Task1
    {
        public static void Run()
        {
            int sum = 0;
            int count = 0;

            using StreamWriter NF = new StreamWriter("no_file.txt", false);
            using StreamWriter BD = new StreamWriter("bad_data.txt", false);
            using StreamWriter OF = new StreamWriter("overflow.txt", false);

            foreach (int i in Enumerable.Range(10,20))
            {
                string Filename = $"{i}.txt";
                int val1, val2;
                
                try
                {
                    string[] lines = File.ReadAllLines(Filename);
                    try
                    {
                        val1 = int.Parse(lines[0].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                        val2 = int.Parse(lines[1].Trim().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                    }
                    catch(Exception ex) when (ex is FormatException || ex  is IndexOutOfRangeException || ex is OverflowException)
                    {
                        BD.WriteLine($"Файл {Filename} містить некоректні дані.");
                        continue;
                    }

                    try
                    {
                        int product = checked(val1 * val2);
                        sum += product;
                        count++;
                    }
                    catch(OverflowException)
                    {
                        OF.WriteLine($"У файлі {Filename} сталася переповнення при обчисленнях.");
                    }
                }
                catch(FileNotFoundException)
                {
                    NF.WriteLine($"Файл {Filename} не знайдено.");
                }
            }
            try
            {
                double average = (double)sum / count;
                Console.WriteLine($"Середнє значення: {average}");
            }
            catch(DivideByZeroException)
            {
                Console.WriteLine("Не вдалося обчислити середнє значення: не було успішно оброблених файлів.");
            }
        }
    }
}