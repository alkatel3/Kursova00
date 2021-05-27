using System;
using System.Collections.Generic;

namespace Kursova00
{
    class Program
    {
        static void Main(string[] args)
        {
            var stations = new List<Station>();
            var AccountsClient = new List<AccountClient>();
            for (; ; )
            {
                Console.WriteLine("Who are you?(input number)");
                Console.WriteLine("1. власник\n2. Покупець\n3. Постачальник\n0. Вийти");
                if (byte.TryParse(Console.ReadLine(), out byte choose_byte1) && choose_byte1 == 1)
                {
                    Console.WriteLine("Do you have station?(input number)\n1.Yes\n2.No");
                    if (Byte.TryParse(Console.ReadLine(), out byte choose_byte2) && choose_byte2 == 1)
                    {
                        Console.WriteLine("Input name you station");
                        foreach (var station in stations)
                        {
                            if (station.NameStation == Console.ReadLine())
                            {
                                Console.WriteLine("Input password your station");
                                if (station.PasswordVerification(Console.ReadLine()))
                                {
                                    Console.WriteLine(station.GetInformation());
                                    
                                }
                                else
                                {
                                    Console.WriteLine("Error");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error");
                                continue;
                            }
                        }
                    }
                    else if (choose_byte2 == 2)
                    {
                        Console.WriteLine("Input name your new station");
                        string name = Console.ReadLine();
                        Console.WriteLine("Input password your new station"); ;
                        string password = Console.ReadLine();
                        Console.WriteLine("Input how much fuel you have");
                        Double.TryParse(Console.ReadLine(), out double fuel);
                        Console.WriteLine("Input how much fuel you may to have");
                             Double.TryParse(Console.ReadLine(), out double max_fuel);
                        Console.WriteLine("Input price your fuel");
                        Double.TryParse(Console.ReadLine(), out double price);
                        var Station = new Station(name, fuel,max_fuel, price, password);
                        stations.Add(Station);
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input");
                        continue;
                    }
                }
                if (choose_byte1 == 2)
                {
                    Console.WriteLine("Do you have account?(input number)\n1. Yes\n2. No");
                    if (Byte.TryParse(Console.ReadLine(), out byte choose_byte3) && choose_byte3 == 1 && AccountsClient != null)
                    {
                        Console.WriteLine("Input name your account:\t");
                        foreach (var account in AccountsClient)
                        {
                            if (account.NameClient == Console.ReadLine())
                            {
                                Console.WriteLine("Input your password:\t");
                                if (account.PasswordVerification(Console.ReadLine()))
                                {
                                    Console.WriteLine(account.GetInformation());
                                    Console.WriteLine("Choose:\n(input number)");
                                    int i = 0; //задає номерацію списку
                                    foreach (var station in stations)
                                    {
                                        Console.WriteLine($"{i++}. {station.InformationForClient()}");
                                    }
                                    if (Int32.TryParse(Console.ReadLine(), out int choose_int1) && choose_int1 > 0 && choose_int1 < i)
                                    {
                                        foreach (var station in stations)
                                        {
                                            if (stations.IndexOf(station) == choose_int1)
                                            {
                                                Console.WriteLine("How much fuel you want?");
                                                if (Double.TryParse(Console.ReadLine(), out double fuel))
                                                {
                                                    Console.WriteLine("Do you want to use bonuses?\n1. Yes\n2. No");
                                                    if (Byte.TryParse(Console.ReadLine(), out byte choose_byte4) && choose_byte4 == 1)
                                                    {
                                                        account.UsingBonus(station.SellingFuel(fuel));
                                                    }
                                                    else if (choose_byte4 == 2)
                                                    {
                                                        Console.WriteLine($"To pay:\t {station.SellingFuel(fuel)} $");
                                                    }
                                                    account.AddingBonus(station.SellingFuel(fuel));
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Incorrect input");
                                                    continue;
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Incorrect input");
                                        continue;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error");
                                continue;
                            }
                        }
                    }
                    else if (choose_byte3 == 2)
                    {
                        Console.WriteLine("Do you want to create account?\n1. Yes\n2. No");
                        if (Byte.TryParse(Console.ReadLine(), out byte choose_byte5) && choose_byte5 == 1)
                        {
                            Console.WriteLine("Input your name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Input password your account"); ;
                            string password = Console.ReadLine();
                            var account_client = new AccountClient(name, password);
                            AccountsClient.Add(account_client);
                        }
                        Console.WriteLine("Choose:\n(input number)");
                        int i = 0; // задає нумерацію списку
                        foreach (var station in stations)
                        {
                            Console.WriteLine($"{i++}. {station.InformationForClient()}");
                        }
                        if (Int32.TryParse(Console.ReadLine(), out int choose_int2) && choose_int2 > 0 && choose_int2 < i)
                        {
                            foreach (var station in stations)
                            {
                                if (stations.IndexOf(station) == choose_int2)
                                {
                                    Console.WriteLine("How much fuel you want?");

                                    if (Double.TryParse(Console.ReadLine(), out double fuel))
                                    {
                                        Console.WriteLine(station.SellingFuel(fuel));
                                    }
                                }
                            }
                        }
                    }
                }
                else if (choose_byte1 == 3)
                {
                    Console.WriteLine("Choose:\n(input number)");
                    int i = 0; //задає номерацію списку
                    foreach (var station in stations)
                    {
                        Console.WriteLine($"{i++}. {station.InformationForProvider()}");
                    }
                    if (Int32.TryParse(Console.ReadLine(), out int choose_int3) && choose_int3 > 0 && choose_int3 < i)
                    {
                        foreach (var station in stations)
                        {
                            if (stations.IndexOf(station) == choose_int3)
                            {
                                Console.WriteLine("How much fuel you have?");
                                if (Double.TryParse(Console.ReadLine(), out double fuel))
                                {
                                    station.BuyFuel(fuel);
                                }
                            }
                        }
                    }
                }
                else if (choose_byte1 == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input");
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}