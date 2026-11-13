using System;

namespace Homework8_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = 12345;
            double price = 99.99;
            string text = "Привет";
            DateTime date = DateTime.Now;
            object nullObject = null;

            Console.WriteLine("=== Проверка объектов ===");

            CheckAndFormat(number);
            CheckAndFormat(price);
            CheckAndFormat(text);
            CheckAndFormat(date);
            CheckAndFormat(nullObject);
        }

        static void CheckAndFormat(object obj)
        {
            if (obj is IFormattable)
            {
                IFormattable formattableObj = obj as IFormattable;
                string formatted = formattableObj.ToString("N2", null);
                Console.WriteLine($"Объект типа {obj.GetType().Name} ПОДДЕРЖИВАЕТ IFormattable. Формат: {formatted}");
            }
            else
            {
                if (obj == null)
                {
                    Console.WriteLine("Объект null НЕ поддерживает IFormattable.");
                }
                else
                {
                    string typeName = obj.GetType().Name;
                    Console.WriteLine($"Объект типа {typeName} НЕ поддерживает IFormattable.");
                }
            }
        }
    }
}