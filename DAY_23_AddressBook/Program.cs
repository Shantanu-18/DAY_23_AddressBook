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
                Console.WriteLine("\n1. Add member to Contact list \n2.View Members in Contact List \n3.Edit Contact " +
                    "\n4.Exit");
                Console.Write("Enter an option:");
                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddressBook.AddMember();
                        break;

                    case 2:
                        AddressBook.ViewContacts();
                        break;

                    case 3:
                        AddressBook.EditDetails();
                        break;


                    case 4:
                        Console.WriteLine("Exited");
                        return;
                }
            }
        }
    }
}
