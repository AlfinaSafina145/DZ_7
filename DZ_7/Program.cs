using System;
using System.IO;
namespace Homework8_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFile = "input_emails.txt";
            string outputFile = "emails.txt";

            if (!File.Exists(inputFile))
            {
                Console.WriteLine($"Файл {inputFile} не найден!");
                return;
            }

            string[] lines = File.ReadAllLines(inputFile);
            string[] resultEmails = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string currentLine = lines[i];

                SearchMail(ref currentLine);
                resultEmails[i] = currentLine;
            }

            File.WriteAllLines(outputFile, resultEmails);
            Console.WriteLine($"Готово! Email-адреса сохранены в файл {outputFile}");
        }
        public static void SearchMail(ref string s)
        {
            int index = s.IndexOf('#');
            if (index != -1)
            {
                s = s.Substring(index + 1).Trim();
            }
            else
            {
                s = "Ошибка: неверный формат";
            }
        }
    }
}