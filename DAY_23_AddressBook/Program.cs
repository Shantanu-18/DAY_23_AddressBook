using System;

namespace DAY_23_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book System");


            while (true)
            {
                Console.WriteLine("\n1. Add member to Contact list \n2.Exit");
                Console.Write("Enter an option:");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddressBook.AddMember();
                        break;
                    
                    case 2:
                        Console.WriteLine("Exited");
                        return;
                }
            }
        }
    }
}
