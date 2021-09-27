using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReadWriteTEXT
{
    // TestPullRequests
    // Написать приложение, которое считает цифры из файла in.txt,
    // выведет в консоль, отсортирует, и запишет в out.txt

    class Program
    {
        static void Main(string[] args)
        {
            string readPath = @"C:\Temp\in.txt";
            string writePath = @"C:\Temp\out.txt";

            List<string> textRead = new List<string>();


            using (StreamReader sr = new StreamReader(readPath))
            {
                string line;
                while ((line = sr.ReadLine()) != null) // построчное чтение до конца файла //
                {
                    string[] lineSubstring = line.Split().Select(s => s).ToArray(); // разделяем строку на отдельные подстроки
                    foreach (var item in lineSubstring)
                    {
                        if (int.TryParse(item, out int result)) // Добавляем в лист только те элементы, которые возможно пребразовать в int
                            textRead.Add(item);
                    }
                }
            }

            // Сортировка текста из файла
            List<string> writeText = textRead.OrderBy(o => int.Parse(o)).ToList();

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
