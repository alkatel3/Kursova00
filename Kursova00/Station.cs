using System;

namespace Kursova00
{
    public class Station
    {
        internal string NameStation{ get; private set; }
        protected double Fuel { get; private set; }
        protected double Price { get; private set; }
        protected string Password { get; private set; }
        protected double MaxFuel { get; private set; }
        internal Station (string name_station,double fuel,double max_fuel, double price, string password)
            
        {
            NameStation = name_station;
            Fuel = fuel;
            MaxFuel = max_fuel;
            Price = price;
            Password = password;
            Console.WriteLine(GetInformation());
        }
        public bool PasswordVerification(string password)
        {
            return Password == password;
        }
        public string GetInformation()
        {
            return $"Your station: {NameStation}\nPassword={Password} \nFuel = {Fuel} l.\nPrise = {Price} $";
        }
        public string InformationForClient()
        {
            return $"Name: {NameStation}\tFuel = {Fuel} l.\tPrise = {Price} $/l";
        }
         public double SellingFuel(double fuel)
        {
            if (fuel <= Fuel)
            {
                Fuel =- fuel;
                return fuel * Price;
            }
            else
            {
                Console.WriteLine("Choose other station");
                return 0;
            }
        }
        public string InformationForProvider()
        {
            return $"Name: {NameStation}\t buy fuel for {Price / 1,3} $"; //Price /1,3 - орієнтовна ціна за яку заправка готова закупляти паливо 
        }
        public double BuyFuel(double fuel)
        {
            if (fuel + Fuel <= MaxFuel)
            {
                Fuel += fuel;
                Console.WriteLine($"Get {fuel * Price / 1,3}");
                return 1; 
            }
            else
            {
                Console.WriteLine("Choose other station");
                return 0;
            }
        }
    }
}