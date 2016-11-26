﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_lab3
{
    class Program
    {
        static void Main(string[] args)
        {

            Zoo zoo = new Zoo();
            zoo.Weiting();
            Console.ReadLine();
            //Vote house2 = dev1.Signal();
            //Vote house = dev2.Signal();


        }
    }

    public class Zoo
    {
        bool isDay = true;
        List<Animal> sd = new List<Animal>();
        public Zoo()
        {
            Animal dev1 = new Giraffe("Жираф", 900);
            Animal dev2 = new Wolf("Волк", 100);
            Animal dev3 = new Bear("Медведь", 300);
            sd.Add(dev1);
            sd.Add(dev2);
            sd.Add(dev3);
        }

        public void Weiting()
        {
            Print();
            Console.WriteLine("Выберите нужное действие:\n1)Вывести общий вес животных в зверинце и средний вес одного животного\n2)Добавить животное в зверинец\n3)Сменить время суток\n4)Подать голос");
            try
            {
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        {
                            int sum = 0;
                            foreach (Animal animal in sd)
                            {
                                sum += animal.Width;
                            }
                            Console.WriteLine("Общий вес животных:{0}, средний вес одного животного:{1}", sum, sum / sd.Count);
                            Console.ReadKey();
                            break;
                        }
                    case 2:
                        {
                            Random r = new Random();
                            int random = r.Next(1, 100);
                            if (random < 21)
                            {
                                Console.WriteLine("Вам выпал жираф!");
                                Console.Write("Введите имя:");
                                string name = Console.ReadLine();
                                Console.Write("Введите вес:");
                                try
                                {
                                    int width = int.Parse(Console.ReadLine());
                                    Animal dev1 = new Giraffe(name, width);
                                    sd.Add(dev1);
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректно введенные данные!");
                                }
                                Console.Write("Животное успешно добавлено в зоопарк!");
                                break;

                            }
                            if (random < 61)
                            {
                                Console.WriteLine("Вам выпал волк!");
                                Console.Write("Введите имя:");
                                string name = Console.ReadLine();
                                Console.Write("Введите вес:");
                                try
                                {
                                    int width = int.Parse(Console.ReadLine());
                                    Animal dev1 = new Wolf(name, width);
                                    sd.Add(dev1);
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректно введенные данные!");
                                }
                                Console.Write("Животное успешно добавлено в зоопарк!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Вам выпал медведь!");
                                Console.Write("Введите имя:");
                                string name = Console.ReadLine();
                                Console.Write("Введите вес:");
                                try
                                {
                                    int width = int.Parse(Console.ReadLine());
                                    Animal dev1 = new Bear(name, width);
                                    sd.Add(dev1);
                                }
                                catch
                                {
                                    Console.WriteLine("Некорректно введенные данные!");
                                }
                                Console.Write("Животное успешно добавлено в зоопарк!");
                                break;

                            }

                        }
                    case 3:
                        {
                            isDay = isDay == true ? false : true;
                            Console.WriteLine("Пора дня изменена успешно!");
                            break;
                        }
                    case 4:
                        {
                            ChoseAnimal();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Некорректно введено число");
                            break;
                        }
                }
            }
            catch
            {
                Console.WriteLine("Некорректно введено число");
                Weiting();
            }
            Weiting();
        }
        void Print()
        {
            Console.WriteLine("\n\n\n------------------------------------------------------------");
            Console.WriteLine("Пора дня:{0}", isDay == true ? "День" : "Ночь");
            Console.WriteLine("Состав зоопарка:");
            foreach (Animal animal in sd)
            {
                Console.WriteLine("Имя: {0}, Вес: {1}", animal.Name, animal.Width);
            }
            Console.WriteLine("------------------------------------------------------------");
        }

        void ChoseAnimal()
        {
            Console.WriteLine("\n\n\n\n\nКакие вы хотите услышать звуки?\n1)Всех вместе\n2Определенного животного");
            try
            {
                int i = int.Parse(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        {
                            foreach (Animal animal in sd)
                            {
                                //animal.SetSuccessor(
                                Console.WriteLine(animal.ToString());

                            }
                            break;
                        }
                }
            }
            catch
            {
                Console.WriteLine("Некорректно введено число");
                ChoseAnimal();
            }

        }
        // абстрактный класс 
        abstract class Animal
        {
            public string Name { get; set; }
            public int Width { get; set; }

            public Animal(string name, int width)
            {
                Name = name;
                Width = width;
            }
            // фабричный метод
            abstract public Vote Signal();
        }

        class Bear : Animal
        {
            public Bear(string name, int width) : base(name, width)
            { }

            public override Vote Signal()
            {
                return new BearSignal();
            }
        }

        class Giraffe : Animal
        {
            public Giraffe(string name, int width) : base(name, width)
            { }

            public override Vote Signal()
            {
                return new GiraffeSignal();
            }
        }

        class Wolf : Animal
        {
            public Wolf(string name, int width) : base(name, width)
            { }

            public override Vote Signal()
            {
                return new WolfSignal();
            }
        }

        abstract class Vote
        { }

        class GiraffeSignal : Vote
        {
            public GiraffeSignal()
            {
                Console.WriteLine("Жираф издает звуки");
            }
        }
        class BearSignal : Vote
        {
            public BearSignal()
            {
                Console.WriteLine("Медведь издает звуки");
            }
        }
        class WolfSignal : Vote
        {
            public WolfSignal()
            {
                Console.WriteLine("Волк издает звуки");
            }
        }
    }
}
