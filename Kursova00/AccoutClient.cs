using System;

namespace Kursova00
{
    class AccountClient
    {
        internal string NameClient { get; private set; }
        protected string Password { get; private set; }
        protected double Bonus { get; private set; }
        internal AccountClient(string name_client, string password)
        {
            NameClient = name_client;
            Password = password;
            Console.WriteLine(GetInformation());
        }
        public string GetInformation()
        {
            return $"You account:\nName: {NameClient}\nPassword: {Password}\nBonus: {Bonus} $";
        }
        public bool PasswordVerification(string password)
        {
            return Password == password;
        }
        public void UsingBonus(double Sum)
        {
            if (Bonus <= Sum)
            {
                Sum -= Bonus;
                Bonus = 0;
                Console.WriteLine($"To pay {Sum} $"); 
            }
            else
            {
                Bonus -= Sum;
                Console.WriteLine("To pay 0 $");
            }
            Console.WriteLine(GetInformation());
        }
        public void AddingBonus(double sum)
        {
            Bonus += sum / 100;
            Console.WriteLine($"You are added {sum / 100} bonus");
            GetInformation();
        }
    }
}
