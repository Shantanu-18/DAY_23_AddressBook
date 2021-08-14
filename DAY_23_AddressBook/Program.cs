using System;
using System.IO;

namespace DAY_23_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book.\n");

            if (File.Exists(@"E:\FellowShip\DAY_23_AddressBook\DAY_23_AddressBook\AddressBook.txt"))
            {
                AddressBook.DeserializePass();
            }
            else
            {
                AddressBook.Serializepass();
            }

            while (true)
            {
                InvalidInput:
                Console.WriteLine("Enter a number\n" +
                    "1. Adding contacts in new addressbook or existing addressbook\n" +
                    "2. Edit a contact\n" +
                    "3. Delete contact\n" +
                    "4. Search and display persons based on their city and state  and their counts\n" +
                    "5. Sort a addressbook based on person's first name\n" +
                    "6. Display complete addressBook\n" +
                    "7. Display a contact based on person's first name\n" +
                    "8. Exit\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        AddressBook.addressBookNewExisting();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 2:
                        AddressBook.EditContact();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 3:
                        AddressBook.DeleteContact();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 4:
                        AddressBook.PersonSearch();
                        break;
                    case 5:
                        AddressBook.AddressBookSorting();
                        AddressBook.Serializepass();
                        AddressBook.DeserializePass();
                        break;
                    case 6:
                        AddressBook.AddressBookDisplay();
                        break;
                    case 7:
                        AddressBook.ContactsDisplay();
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("PLEASE ENTER A VALID NUMBER\n");
                        goto InvalidInput;
                }
            }
        }
    }
}
