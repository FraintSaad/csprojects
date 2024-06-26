﻿using ConsoleUtils;
using System.Runtime.CompilerServices;

namespace movsar_part4
{
    internal class CakesImproved
    {
        public static void Start()
        {
            const string PATH = @"CakesPrice.txt";

            // Выбор режима
            Dictionary<char, string> options = new Dictionary<char, string>{
                { '1', "Выбор торта" },
                { '2', "Внести в прайс новый торт" }
            };
            char selectedOption = InputService.GetOption("Выберите дествие", options);


            switch (selectedOption)
            {
                case '1':
                    Console.WriteLine("Введите название торта: ");
                    string? selectedName = InputService.GetString();
                    if (selectedName == null)
                    {
                        Console.WriteLine("Ошибка!");
                        return;
                    }

                    string contents = File.ReadAllText(PATH);
                    string[] entries = contents.Split("\r\n");

                    bool found = false;

                    for (int i = 0; i < entries.Length - 1; i++)
                    {
                        string entry = entries[i].ToLower();

                        if (entry.Contains(selectedName.ToLower()))
                        {
                            found = true;
                            string[] data = entry.Split(" ");
                            Console.WriteLine($"Название торта: {data[0]}, Цена: {data[1]} руб.");
                        }
                    }
                    if (found == false)
                    {
                        Console.WriteLine("Нет такого торта");
                    }
                    Console.ReadKey();
                    Start();
                    break;

                case '2':
                    Console.WriteLine("Введите данные о торте");

                    Console.Write("Название торта: ");
                    string? date = InputService.GetString();
                    if (date == null)
                    {
                        Console.WriteLine("Ошибка!");
                        return;
                    }

                    Console.WriteLine("Цена торта: ");
                    int? price = InputService.GetInt();
                    if (price == null)
                    {
                        Console.WriteLine("Ошибка!");
                        return;
                    }

                    try
                    {
                        File.AppendAllText(PATH, $"{date} {price}\r\n");
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine("Нет доступа к указанному пути");
                        return;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Возникла непонятная ошибка");
                        return;
                    }

                    Console.WriteLine("Данные о торте успешно добавлены в файл");
                    Console.ReadKey();
                    Start();

                    break;

                
            }
        }
    }
}
