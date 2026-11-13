using System;
using System.IO;
namespace Homework8_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя исходного файла (например, input.txt): ");
            string sourceFile = Console.ReadLine();

            if (!File.Exists(sourceFile))
            {
                Console.WriteLine("Ошибка: файл с таким именем не существует.");
                return;
            }
            try
            {
                string content = File.ReadAllText(sourceFile);
                string upperContent = content.ToUpper();
                string outputFile = "output.txt";
                File.WriteAllText(outputFile, upperContent);
                Console.WriteLine($"Успех! Содержимое скопировано в файл '{outputFile}' заглавными буквами.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при работе с файлом: {ex.Message}");
            }
        }
    }
}