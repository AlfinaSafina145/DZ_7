using System;
using System.Collections.Generic;

namespace CompanyHierarchy
{
    class Employee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"{Position}: {Name}");
        }
    }

    // Класс Начальника (умеет давать задачи)
    class Manager : Employee
    {
        public List<Employee> Subordinates { get; set; } = new List<Employee>();

        public Manager(string name, string position) : base(name, position) { }

        public void AddSubordinate(Employee emp)
        {
            Subordinates.Add(emp);
        }

        // Метод постановки задачи
        public void AssignTask(string taskName, Employee targetEmployee)
        {
            Console.WriteLine($"\n[Процесс] {Name} ({Position}) ставит задачу: '{taskName}' для {targetEmployee.Name}...");

            // Проверяем, есть ли этот сотрудник в прямом подчинении
            bool isDirectSubordinate = false;
            foreach (var sub in Subordinates)
            {
                if (sub == targetEmployee)
                {
                    isDirectSubordinate = true;
                    break;
                }
            }

            if (isDirectSubordinate)
            {
                // прямой подчиненный
                Console.WriteLine($"-> УСПЕХ: {targetEmployee.Name} берет задачу '{taskName}'.");
            }
            else
            {
                // Если не прямой, ищем, через кого передать
                bool delegated = false;
                foreach (var sub in Subordinates)
                {
                    if (sub is Manager managerSub)
                    {
                        // Если подчиненный - тоже менеджер, пробуем передать через него
                        managerSub.AssignTask(taskName, targetEmployee);
                        delegated = true;
                        break;
                    }
                }

                if (!delegated)
                {
                    Console.WriteLine($"-> ОТКАЗ: {Name} не может дать задачу {targetEmployee.Name} напрямую (нет в подчинении).");
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Manager timur = new Manager("Тимур", "Генеральный директор");

            Manager rashid = new Manager("Рашид", "Финансовый директор");
            Manager lukas = new Manager("Лукас", "Главный бухгалтер");

            Manager oilham = new Manager("ОИльхам", "Директор по автоматизации");
            Manager orkadiy = new Manager("Оркадий", "Начальник инф систем");
            Manager volodya = new Manager("Володя", "Зам начальника");

            Manager ilshat = new Manager("Ильшат", "Главный в секторе системщиков");
            Manager ilya = new Manager("Илья", "Сотрудник");
            Manager vitya = new Manager("Витя", "Сотрудник");
            Manager zhenya = new Manager("Женя", "Сотрудник");

            Manager sergey = new Manager("Сергей", "Главный в секторе разработчиков");
            Manager laysan = new Manager("Лайсан", "Зам");
            Employee marat = new Employee("Марат", "Разработчик");
            Employee dina = new Employee("Дина", "Разработчик");
            Employee ildar = new Employee("Ильдар", "Разработчик");
            Employee anton = new Employee("Антон", "Разработчик");

            // 2. Строим связи
            timur.AddSubordinate(rashid);
            timur.AddSubordinate(oilham);

            rashid.AddSubordinate(lukas);

            oilham.AddSubordinate(orkadiy);
            orkadiy.AddSubordinate(volodya);

            volodya.AddSubordinate(ilshat);
            volodya.AddSubordinate(sergey);

            ilshat.AddSubordinate(ilya);
            ilshat.AddSubordinate(vitya);
            ilshat.AddSubordinate(zhenya);

            sergey.AddSubordinate(laysan);
            laysan.AddSubordinate(marat);
            laysan.AddSubordinate(dina);
            laysan.AddSubordinate(ildar);
            laysan.AddSubordinate(anton);

            
            Console.WriteLine("=== ТЕСТ 1: Прямое подчинение ===");
            // прямой подчиненный
            timur.AssignTask("Подготовить финансовый отчет", rashid);

            Console.WriteLine("\n=== ТЕСТ 2: Задача через цепочку ===");
            // Илья не прямой подчиненный Оркадия, он подчиненный Ильшата
            orkadiy.AssignTask("Починить сервер", ilya);

            Console.WriteLine("\n=== ТЕСТ 3: Задача через длинную цепочку ===");
            // Тимур ставит задачу Марине (через 5 уровней)
            timur.AssignTask("Написать новый модуль", marat);

            Console.WriteLine("\n=== ТЕСТ 4: Нарушение иерархии ===");
            // Ильшат пытается дать задачу Дина (она в другом отделе)
            ilshat.AssignTask("Проверить сеть", dina);
        }
    }
}