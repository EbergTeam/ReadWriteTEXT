using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadWriteTEXT
{
    // TestPool
    // Написать приложение, которое считает цифры из файла in.txt,
    // выведет в консоль, отсортирует, и запишет в out.txt

    class Program
    {
        static void Main(string[] args)
        {
            // Пути файлов для чтения/записи
            string readPath = @"C:\Temp\in.txt";
            string writePath = @"C:\Temp\out.txt";
            // Коллекция входных данных из файла
            List<string> textRead = new List<string>();
            // Коллекция отфильтрованных входных данных по linq-запросу
            List<int> textUpdate = new List<int>();;

            // Чтение и фильтрация данных из файла
            textRead = File.ReadAllLines(readPath).ToList();
            foreach (var item in textRead)
            {
                textUpdate.AddRange(item.Split().Where(w => int.TryParse(w, out int result)).Select(s => int.Parse(s)).ToList());
            }              
           
            // Сортировка данных
            List<int> writeText = textUpdate.OrderBy(o => o).ToList();

            // Вывод на консоль
            foreach (var item in writeText)
            {
                Console.WriteLine(item);
            }

            // Запись текста по пути writePath
            using (StreamWriter sw = new StreamWriter(writePath, false))
            {
                foreach (var item in writeText)
                {
                    sw.WriteLine(item);
                }
            }

            Console.ReadLine();
        }
    }
}
