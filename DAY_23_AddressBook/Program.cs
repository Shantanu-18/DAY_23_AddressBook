using System;

namespace DAY_23_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book.");
            Console.WriteLine();

            AddressBook.addAddressBook();

            while (true)
            {
                Console.WriteLine("\nEnter your choice \n 1. To Display Address book \n 2. To edit the existing contact" +
                   " \n 3. To delete contact \n 4. To search person by city or state" +
                   " \n 5. To sort and Display Address Book Alphabetically \n 6. To sort and Display Address Book" +
                   " by City, State, Zip \n 7. To Exit.");

                int choice = int.Parse(Console.ReadLine());


                switch (choice)
                {
                    case 1:
                        AddressBook.ContactsDisplay();
                        break;

                    case 2:
                        AddressBook.EditContact();
                        break;

                    case 3:
                        AddressBook.DeleteContact();
                        break;

                    case 4:
                        AddressBook.PersonSearch();
                        break;

                    case 5:
                        AddressBook.SortEntriesAlphabetically();
                        break;

                    case 6:
                        AddressBook.SortByCityStateZip();
                        break;

                    case 7:
                        Console.WriteLine("Thank you.");
                        break;

                    default:
                        Console.WriteLine("Enter valid choice.");
                        break;
                }

            }
        }
    }
}
