using System;

namespace Lab_6_OOP
{
    class Program
    {
        static void Main()
        {
            while(true)
            {
                Console.WriteLine("Оберіть завдання (1-2) або введіть 0 для виходу:");
                Console.WriteLine("1. Завдання 1: Обробка текстових файлів");
                Console.WriteLine("2. Завдання 2: Обробка зображень");
                Console.WriteLine("0. Вихід");
                
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Task1.Run();
                            break;
                        case "2":
                            Task2.Run();
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Сталася помилка: {ex.Message}");
                }
            }
        }
    }
}