using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DB_RieltorCompany
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WindowWidth = 140;

            Clients myClients = new Clients("clients.csv");
            Flats myFlats = new Flats("data.csv", myClients);
            

            string choise;

            do
            {
                showFlats(myFlats);

                Console.WriteLine("Что ты хочешь делать?");
                Console.WriteLine("1-удалить объект недвижимости");
                Console.WriteLine("2-добавить объект недвижимости");
                Console.WriteLine("3-изменить объект недвижимости");
                Console.WriteLine("4-показать таблицу клиентов");
                Console.WriteLine("5-показать кто купил дом");
                Console.WriteLine("6-хочу выйти.");
                choise = Console.ReadLine();

                if (choise == "1") { Delete(ref myFlats); }
                if (choise == "2") { append(ref myFlats, myClients); }
                if (choise == "3") { Change(ref myFlats, myClients); }
                if (choise == "4") { showClients(myClients); }
                if (choise == "5") { showLinked(myFlats, myClients); }

                Console.Clear();
            } while (choise != "6");

            Console.WriteLine("Сохранить базу данных?(y/n)");
            string isSaveData = Console.ReadLine().ToLower();

            if (isSaveData == "y")//сохранение файла
            {
                myFlats.saveFlatsToFile();
                Console.WriteLine("База сохранена...");
            }

        }
        #region Вывод на консоль
        static void showFlats(Flats flatsTable)
        {
            string tmpStr = "";
            foreach (string item in flatsTable.Title.Split(';'))
            {
                tmpStr += item + "\t";
            }
            tmpStr += "\n";

            for (int i = 0; i < flatsTable.flatsCount; i++)
            {
                tmpStr += flatsTable.getFlat(i).ToString("\t") + "\n";
            }

            Console.WriteLine(tmpStr);
        }
        static void showClients(Clients clientsTable)
        {
            string tmpStr = "";
            foreach (string item in clientsTable.Title.Split(';'))
            {
                tmpStr += item + "\t";
            }
            tmpStr += "\n";

            for (int i = 0; i < clientsTable.clientsCount; i++)
            {
                tmpStr += clientsTable.getClient(i).ToString("\t") + "\n";
            }

            Console.WriteLine(tmpStr);
            Console.ReadKey();
        }
        #endregion

        static void Delete(ref Flats flatsTable)//удаление строки
        {
            try
            {
                Console.WriteLine("Введи ID недвижимости для удаления");
                int numberForDelete = flatsTable.getNumberByID(Convert.ToInt32(Console.ReadLine()));
                flatsTable.remove(flatsTable.getFlat(numberForDelete));
            }
            catch (FormatException e)
            {
                Console.WriteLine("Необходимо вводить числа!!!!\n" + e);
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Нет недвижимости с таким номером!!!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка, которую я не смог предпологать");
                Console.WriteLine(e.Data);
                Console.WriteLine(e.Message);
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
        }

        static void append(ref Flats flatsTable, Clients clients)//добавить строку
        {
            string newDataStringFor = flatsTable.getFlat(flatsTable.flatsCount-1).ID+1 + ";";//новый айди добавил в строку
            string s = "";
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("Введи "  + flatsTable.Title.Split(';')[i]);
                //if (i == 2 | i == 3 | i == 4 | i == 5 | i == 8) { Console.WriteLine("(Цифры)"); }
                s = Console.ReadLine();
                if (s.Trim() == "")
                {
                    Console.WriteLine("Введи хоть что нибудь!");
                    i -= 1;
                }
                else
                {
                    newDataStringFor += s.Trim() + ";";
                }
            }
            newDataStringFor = newDataStringFor.Substring(0, newDataStringFor.Length - 1);//убрал последнюю запитую
            try
            {
                if (Convert.ToInt32(newDataStringFor.Split(';')[8]) > 0 && Convert.ToInt32(newDataStringFor.Split(';')[8]) < 5)
                {
                    flatsTable.add(new Flat(newDataStringFor, clients));//добавил новый объект этой строкой в конструкторе в лист 
                }
                else
                {
                    Console.WriteLine("Введенно неверное значение");
                    Console.ReadKey();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Введенно неверное значение" + e);
                Console.ReadKey();
            }
        }


        static void Change(ref Flats flatsTable, Clients clients)//изменить строку
        {
                try
                {
                    Console.WriteLine("Введи ID для изменения");
                    int numberForChange = flatsTable.getNumberByID(Convert.ToInt32(Console.ReadLine()));
                    string newDataStringFor = flatsTable.getFlat(numberForChange).id.ToString() + ";";//айди + точка с запятой
                    string s = "";
                    for (int i = 1; i < 9; i++)
                    {
                        Console.WriteLine("Введи " + flatsTable.Title.Split(';')[i]);
                        //if (i == 2 | i == 3 | i == 4 | i == 5 | i == 8) { Console.WriteLine("(Цифры)"); }
                        s = Console.ReadLine();
                        if (s.Trim() == "")
                        {
                            Console.WriteLine("Введи хоть что нибудь!!!");
                            i -= 1;
                        }
                        else
                        {
                            newDataStringFor += s.Trim() + ";";
                        }
                    }
                    newDataStringFor = newDataStringFor.Substring(0, newDataStringFor.Length - 1);
                    try
                    {
                    if (Convert.ToInt32(newDataStringFor.Split(';')[8]) > 0 && Convert.ToInt32(newDataStringFor.Split(';')[8]) < 5)
                    {
                        flatsTable.change(numberForChange, new Flat(newDataStringFor, clients));
                    }
                    else
                    {
                        Console.WriteLine("Введенно неверное значение");
                        Console.ReadKey();
                    }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Введенно неверное значение\t" + e);
                        Console.ReadKey();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("При изменении произошла ошибка...скорее всего такого номера недвижимости не существует");
                    Console.ReadKey();
                }
        }

        static void showLinked(Flats flats, Clients clients)//показывает связанные по айдишнику строки
        {
            Console.WriteLine("Введи ID дома");
            int number = flats.getNumberByID(Convert.ToInt32(Console.ReadLine()));
            if (number > -1)
            {
                int foundedNumber = -1;
                int clientID = flats.getFlat(number).ClientID ;//сравнивает номера айдишников
                for (int i = 0; i < clients.clientsCount; i++)
                {
                    if (clientID == clients.getClient(i).id)
                    {
                        foundedNumber = i;
                        break;
                    }
                }
                if (foundedNumber == -1)
                {
                    Console.WriteLine("Я не знаю кто купил этот дом");
                }
                else
                {
                    Console.WriteLine(clients.getClient(foundedNumber).ToString("\t"));
                }
            }
            else
            {
                Console.WriteLine("Такого ID нет");
            }

            Console.ReadKey();

        }

    }
}
