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
                try
                {
                    string[] lines = File.ReadAllLines(Filename);

                    int val1 = int.Parse(lines[0].Trim().Split()[0]);
                    int val2 = int.Parse(lines[1].Trim().Split()[0]);

                    int product = val1 * val2;

                    sum += product;
                    count++;
                }
                catch(FileNotFoundException)
                {
                    NF.WriteLine(Filename);
                }
                catch(Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
                {
                    BD.WriteLine($"Файл {Filename} містить некоректні дані.");
                }
                catch(OverflowException)
                {
                    OF.WriteLine($"У файлі {Filename} сталася переповнення при обчисленнях.");
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