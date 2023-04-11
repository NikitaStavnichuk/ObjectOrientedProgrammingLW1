using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Lab1
{
    internal class Program
    {
        public struct Person
        {
            public string _name; 
            public string _lastName;
            public Person(string name, string lastName)
            {
                _name = name;
                _lastName = lastName;
            }
            public string GetFullName()
            {
                return $"Имя: {_name}; Фамилия: {_lastName}";
            }
        }

        static int Input()
        {

            int num;
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out num))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный ввод!");
                    Console.Write("Введите число ещё раз: ");
                }
            }
            return num;
        }
        static void Main(string[] args)
        {
            int number;
            Console.WriteLine("Решение какой задачи открыть (1, 2 или 3)? ");
            number = Input();
            switch (number)
            {
                case 1:
                    {
                        Random random = new Random();
                        float[] mass;
                        int N, i;
                        float sum = 0;
                        while (true)
                        {
                            Console.WriteLine("Введите количество элементов массива: ");
                            N = Input();
                            if (N > 0)
                            {
                                mass = new float[N];
                                for (i = 0; i < mass.Length; i++)
                                {
                                    mass[i] = random.Next(-100, 100);
                                }
                                for (i = 0; i < mass.Length; i++)
                                {
                                    if (mass[i] % 3 == 0)
                                    {
                                        sum += mass[i];
                                    }
                                }
                                for (i = 0; i < mass.Length; i++)
                                {
                                    Console.Write(mass[i] + " ");
                                }
                                Console.WriteLine();
                                Console.WriteLine("Элементы, делящиеся на 3: ");
                                for (i = 0; i < mass.Length; i++)
                                {
                                    if (mass[i] % 3 == 0) Console.Write(mass[i] + " ");
                                }
                                Console.WriteLine();
                                Console.WriteLine($"Сумма элементоав массива, значения которых кратны 3: {sum}");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Массив не может быть 0-ого размера! Введите размерность заново.");
                            }
                        }
                        break;
                    }
                case 2:
                    {
                        Random random = new Random();
                        int[,] mass;
                        int N, M, i, j, i1 = 0, j1 = 0, min;
                        while (true)
                        {
                            Console.WriteLine("Введите размерность массива: ");
                            N = Input();
                            M = Input();
                            if (N > 0 && M > 0)
                            {
                                mass = new int[N, M];
                                for (i = 0; i < N; i++)
                                {
                                    for (j = 0; j < M; j++)
                                    {
                                        mass[i, j] = random.Next(-100, 100);
                                    }
                                }
                                min = mass[0, 0];
                                for (i = 0; i < N; i++)
                                {
                                    for (j = 0; j < M; j++)
                                    {
                                        if (mass[i, j] < min)
                                        {
                                            mass[i, j] = min;
                                            i1 = i;
                                            j1 = j;
                                        }
                                    }
                                }
                                for (i = 0; i < N; i++)
                                {
                                    for (j = 0; j < M; j++)
                                    {
                                        Console.Write(mass[i, j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine($"Минимальный элемент mass[{i1 + 1}, {j1 + 1}] = {min}");
                                for (i = 0; i < N; i++)
                                {
                                    for (j = 0; j < M; j++)
                                    {
                                        if (i1 == i || j1 == j)
                                        {
                                            mass[i, j] = 0;
                                        }
                                    }
                                }
                                Console.WriteLine("Обнуление элементов всех строк и столбцов, на пересечении которых расположено найденное значение:");
                                for (i = 0; i < N; i++)
                                {
                                    for (j = 0; j < M; j++)
                                    {
                                        Console.Write(mass[i, j] + " ");
                                    }
                                    Console.WriteLine();
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Массив не может быть 0-ого размера! Введите размерность заново.");
                            }

                        }
                        break;
                    }
                case 3:
                    {
                        int countPeople, menu;
                        List<Person> students = new List<Person>();
                        Console.WriteLine("Список фамилий и имён персонажей.\n");
                        Console.WriteLine("Сколько требуется ввести имён и фамилий персонажей?: ");
                        countPeople = Input();
                        Console.Clear();
                        int i;
                        for (i = 0; i < countPeople; i++)
                        {
                            var student = new Person();
                            Console.WriteLine($"Введите имя {i + 1} персонажа:");
                            student._name = Console.ReadLine();
                            Console.WriteLine($"Введите фамилию {i + 1} персонажа:");
                            student._lastName = Console.ReadLine();
                            students.Add(student);
                        }
                        Console.Clear();
                        Console.WriteLine("Фамилии и имена персонажкей: \n");
                        students.ForEach(s => Console.WriteLine(s.GetFullName()));
                        Console.WriteLine();
                        while (true)
                        {
                            Console.WriteLine("Что будем делать дальше: \n");
                            Console.WriteLine("(1) - удалить имя и фамилию персонажа; \n");
                            Console.WriteLine("(2) - добавить имя и фамилию персонажа; \n");
                            Console.WriteLine("(3) - вывести список персонажей; \n");
                            Console.WriteLine("(4) - вывести тех персонажей, у которых фамилия состоит более, чем из 11 букв; \n");
                            Console.WriteLine("(5) - выход; \n");
                            menu = Input();
                            Console.Clear();
                            switch (menu)
                            {
                                case 1:
                                    Console.WriteLine("Фамилии и имена персонажкей: \n");
                                    students.ForEach(s => Console.WriteLine(s.GetFullName()));
                                    int delete;
                                    Console.WriteLine("Введите порядковый номер персонажа, которого нужно удалить: ");
                                    delete = Input();
                                    for (i = 0; i < students.Count; i++)
                                    {
                                        if (i + 1 == delete)
                                        {
                                            students.Remove(students[i]);
                                        }
                                    }
                                    break; 
                                case 2:
                                    var student = new Person();
                                    Console.WriteLine($"Введите имя персонажа:");
                                    student._name = Console.ReadLine();
                                    Console.WriteLine($"Введите фамилию персонажа:");
                                    student._lastName = Console.ReadLine();
                                    students.Add(student);
                                    break;
                                case 3:
                                    Console.WriteLine("Фамилии и имена персонажкей: \n");
                                    students.ForEach(s => Console.WriteLine(s.GetFullName()));
                                    break;
                                case 4:
                                    int count = 0;
                                    Console.WriteLine("Персонажи, у которых фамилия состоит более, чем из 11 букв: \n");
                                    for (i = 0; i < students.Count; i++)
                                    {
                                        if ((students[i]._lastName).Length > 11)
                                        {
                                            Console.WriteLine(students[i]._name + " " + students[i]._lastName);
                                            count++;
                                        }
                                    }
                                    if (count == 0)
                                    {
                                        Console.WriteLine("Таких людей нет!");
                                    }
                                    break;
                                case 5:
                                    Environment.Exit(1);
                                    break;
                                default:
                                    Console.WriteLine("Неверная команда! Повторите ввод:\n");
                                    break;
                            }
                        }
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Введено неккоректное значение \n");
                        Console.Read();
                        break;
                    }
            }
        }
    }
}
