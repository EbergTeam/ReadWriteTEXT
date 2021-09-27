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

            // Коллекция для входных данных
            List<int> textRead = new List<int>();

            using (StreamReader sr = new StreamReader(readPath))
            {
                sr.ReadToEnd();
                string line;
                while ((line = sr.ReadLine()) != null) // построчное чтение до конца файла
                {
                    List<int> lineSubstring = line.Split().Where(w => int.TryParse(w, out int result)).Select(s => int.Parse(s)).ToList(); // разделяем строку на подстроки + фильтр элементов которые возможно пребразовать в int + преобразуем в int
                    foreach (var item in lineSubstring)
                    { 
                            textRead.Add(item);
                    }
                }
            }

            // Сортировка текста из файла
            List<int> writeText = textRead.OrderBy(o => o).ToList();

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
