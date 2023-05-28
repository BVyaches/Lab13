using NewHashTable;
using ChallengeLibrary;
using CI = ChallengeLibrary.ConsoleInteraction;
using System.Diagnostics.CodeAnalysis;

namespace lab
{
    [ExcludeFromCodeCoverage]
    internal class Program
    {
        static void Main()
            {
            int[] parameters;
            int currentMenu = 0, currentFunc = 0;
            NewHashTable<Challenge> table1 = new("Первая");
            NewHashTable<Challenge> table2 = new("Вторая");
            NewHashTable<Challenge> table = new("");

            table1.RandomInit(0);
            table2.RandomInit(0);

            Journal firstCollectionJournal = new Journal();
            Journal referenceJournal= new Journal();

            table1.CollectionCountChanged += new CollectionHandler(firstCollectionJournal.CollectionCountChanged);
            table1.CollectionReferenceChanged += new CollectionHandler(firstCollectionJournal.CollectionReferenceChanged);

            table1.CollectionReferenceChanged += new CollectionHandler(referenceJournal.CollectionReferenceChanged);
            table2.CollectionReferenceChanged += new CollectionHandler(referenceJournal.CollectionReferenceChanged);

            while (currentMenu!=10)
            {
                parameters = CI.ChooseMenu(currentMenu);
                currentMenu = parameters[0];
                currentFunc = parameters[1];
                if (currentMenu == 1)
                {
                    table = table1;
                }
                else if (currentMenu == 2)
                {
                    table = table2;
                }
                switch (currentFunc)
                {
                        
                    // Создание таблицы
                    case 0:
                        {
                            int length = CI.GetInt(true, true, "Введите длину таблицы для генерации");
                            bool result = table.RandomInit(length);
                            if (result)
                            {
                                Console.WriteLine("Таблица успешно создана:");
                                table.Show();
                            }
                            else
                            {
                                Console.WriteLine("Похоже, дерево с заданным размером создать невозможно");

                            }
                            break;
                        }


                    // Добавление элемента
                    case 1:
                        {
                            Console.WriteLine("Вы работаете со таблицей:");
                            table.Show();
                            Console.WriteLine();

                            Console.WriteLine("Создайте элемент для добавления:");
                            Challenge challenge = CI.ManualChallenge(table.ToString() + "\nСоздайте элемент для добавления");

                            table.Add(challenge);
                            Console.WriteLine("\nЭлемент успешно добавлен:");
                            table.Show();
                            break;
                        }

                        
                    // Печать таблицы
                    case 2:
                        {
                            Console.WriteLine("Вы работаете с таблицей:");
                            table.Show();
                            break;
                        }

                    // Удаление элемента
                    case 3:
                        {
                            if (table.Count == 0)
                            {
                                Console.WriteLine("Похоже, вы не создали таблицу");
                                break;
                            }

                            Console.WriteLine("Текущая таблица:");

                            table.Show();

                            if (table.IsEmpty())
                            {
                                break;
                            }
                            Console.WriteLine("Какой элемент хотите удалить (ключ)?");
                            Challenge toFind = new();
                            toFind.Init();


                            bool result = table.Remove(toFind);
                            if (result)
                            {
                                Console.WriteLine("\nЭлемент успешно удалён:");
                                table.Show();
                            }
                            else
                            {
                                Console.WriteLine("Похоже, данный элемент отсутствует в хэштаблице");
                            }

                            break;
                        }

                        
                    // Индексатор
                    case 4:
                        {
                            if (table.Count == 0)
                            {
                                Console.WriteLine("Похоже, таблица пустая, попробуйте создать её!");
                                break;
                            }
                            Challenge key = new();
                            table.Show();
                            Console.WriteLine("Введите ключ, по которому надо поменять элемент:");
                            key.Init();
                            if (!table.FindPoint(key, out _, out _))
                            {
                                Console.WriteLine("Похоже, по данному ключу нет данных");
                                break;
                            }
                            Challenge newData = CI.ManualChallenge(table.ToString() + "Что вписать в данный ключ?");

                            try
                            {
                                table[key] = newData;
                                Console.WriteLine("Таблица после изменений:");
                                table.Show();
                            }
                            catch
                            {
                                Console.WriteLine("Похоже, по данному ключу нет данных");
                            }


                            break;
                        }

                    case 9:
                        {
                            Console.WriteLine("Данные журналов:");
                            Console.WriteLine("Данные первого журнала:");
                            Console.WriteLine(firstCollectionJournal);
                            Console.WriteLine();
                            Console.WriteLine("Данные второго журнала:");
                            Console.WriteLine(referenceJournal);
                            break;
                        }


                    // Завершение работы
                    case 10:
                        {
                            Console.WriteLine($"{currentMenu}, {currentFunc}");
                            Console.WriteLine("Хорошего дня!");
                            break;
                        }
                }
                Console.WriteLine("\n\nНажмите любую клавишу для возвращения в меню");
                Console.ReadLine();

                
            }
        }
    }
}