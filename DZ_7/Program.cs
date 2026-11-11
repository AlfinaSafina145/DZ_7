using System;
namespace Task8_2
{
    class Program
    {
        static string ReverseString(string input)
        {
            if (input == null || input == "")
            {
                return input;
            }
            char[] charArray = input.ToCharArray();
            char[] resultArray = new char[charArray.Length];
            for (int i = 0; i < charArray.Length; i++)
            {
                resultArray[i] = charArray[charArray.Length - i - 1];
            }
            return new string(resultArray);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Тест 1");
            string word1 = "Привет!";
            string result1 = ReverseString(word1);
            Console.WriteLine($"Оригинал: {word1}");
            Console.WriteLine($"Перевернутое: {result1}\n");

            Console.WriteLine("Тест 2");
            string word2 = "Си шарп ";
            string result2 = ReverseString(word2);
            Console.WriteLine($"Оригинал: {word2}");
            Console.WriteLine($"Перевернутое: {result2} \n");

            Console.WriteLine("Тест 3");
            string word3 = "";
            string result3 = ReverseString(word3);
            Console.WriteLine($"Оригинал: {word3}");
            Console.WriteLine($"Перевернутое: {result3}");
        }
    }
}