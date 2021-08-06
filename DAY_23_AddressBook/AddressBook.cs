using System;
using System.Collections.Generic;
using System.Text;

namespace DAY_23_AddressBook
{
    class AddressBook
    {
        public static Dictionary<string, List<Contacts>> myDictAddress = new Dictionary<string, List<Contacts>>();
        public static List<Contacts> addressBook;

        public static void addAddressBook()
        {
            Console.Write("How many addressbooks do you want to create: ");
            int count = Convert.ToInt32(Console.ReadLine());
            while (count > 0)
            {
                Console.WriteLine("Do you want to add the contact in the existing addressbook or new addressbook" +
                    "\n Enter the number accordingly\n 1. New addressbook\n 2. Existing addressbook");
                int key = Convert.ToInt32(Console.ReadLine());
                if (key == 1)
                {
                    NewNameAddressBookValidator();
                }
                else if (key == 2)
                {
                    ExistingNameAddressBookValidator();
                }
                count--;
            }
        }

        public static void NewNameAddressBookValidator()
        {
            Console.Write("Enter the new addressbook name: ");
            string addressBookName = Console.ReadLine();
            if (myDictAddress.ContainsKey(addressBookName))
            {
                Console.WriteLine("\nPlease enter a new addressbook name. The name entered already exist");
                NewNameAddressBookValidator();
            }
            else
            {
                myDictAddress[addressBookName] = new List<Contacts>();
                AddContact(addressBookName);
            }
        }
        public static void ExistingNameAddressBookValidator()
        {
            Console.Write("Enter the Existing addressbook name: ");
            string addressBookName = Console.ReadLine();
            if (!myDictAddress.ContainsKey(addressBookName))
            {
                Console.WriteLine("\nPlease enter a new addressbook name. The name entered already exist");
                ExistingNameAddressBookValidator();
            }
            else
            {
                AddContact(addressBookName);
            }
        }
        public static void AddContact(string addressBookName)
        {
            Console.Write("How many person's contact details do you want to add? ");
            int personNum = Convert.ToInt32(Console.ReadLine());
            while (personNum > 0)
            {
                Contacts person = new Contacts();
            firstName:
                Console.Write("Enter your First name: ");
                string firstName = Console.ReadLine();
                if (NameDuplicationCheck(addressBookName, firstName))
                {
                    person.firstName = firstName;
                }
                else
                {
                    Console.WriteLine("The name {0} already  exist in the current address book. " +
                        "please enter a new name", firstName);
                    goto firstName;
                }

                Console.Write("Enter your Last name: ");
                person.lastName = Console.ReadLine();
                Console.Write("Enter your address: ");
                person.address = Console.ReadLine();
                Console.Write("Enter your city: ");
                person.city = Console.ReadLine();
                Console.Write("Enter your State: ");
                person.state = Console.ReadLine();
                Console.Write("Enter your Zip code: ");
                person.ZipCode = Console.ReadLine();
                Console.Write("Enter your Phone number: ");
                person.PhoneNumber = Console.ReadLine();
                Console.Write("Enter your Email ID: ");
                person.eMail = Console.ReadLine();

                myDictAddress[addressBookName].Add(person);
                Console.WriteLine("{0}'s contact succesfully added", person.firstName);
                Console.WriteLine();

                personNum--;
            }
        }

        public static bool NameDuplicationCheck(string addressBookName, string firstName)
        {
            int flag = 0;
            if (myDictAddress[addressBookName].Count > 0)
            {
                foreach (Contacts contact in myDictAddress[addressBookName])
                {
                    if (!(contact.firstName == firstName))
                    {
                        flag = 1;
                    }
                    else
                    {
                        flag = 0;
                        break;
                    }
                }
            }
            else
            {
                return true;
            }
            if (flag == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static void ContactsDisplay()
        {
            Console.Write("Enter the name of the addressbook that you wants to use for displaying contacts: ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine();
            if (myDictAddress[addressBookName].Count > 0)
            {
                foreach (Contacts contact in myDictAddress[addressBookName])
                {
                    Console.WriteLine($"First name-->{contact.firstName}");
                    Console.WriteLine($"Last name-->{contact.lastName}");
                    Console.WriteLine($"Address-->{contact.address}");
                    Console.WriteLine($"City-->{contact.city}");
                    Console.WriteLine($"State-->{contact.state}");
                    Console.WriteLine($"Zip code-->{contact.ZipCode}");
                    Console.WriteLine($"Phone number-->{contact.PhoneNumber}");
                    Console.WriteLine($"E-Mail ID-->{contact.eMail}");
                    Console.WriteLine();

                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
        }

        public static void EditContact()
        {
            Console.Write("Enter the name of the addressbook that you wants to use for editing contacts: ");
            string addressBookName = Console.ReadLine();
            Console.Write("Enter the first name of the person whoom you want to edit the details: ");
            string editKey = Console.ReadLine();
            int flag = 0;
            if (myDictAddress[addressBookName].Count > 0)
            {
                foreach (Contacts contact in myDictAddress[addressBookName])
                {
                    if (editKey.ToLower() == contact.firstName.ToLower())
                    {
                        while (true)
                        {
                            Console.WriteLine("Enter the key number for editing the details\n 1. First name\n 2. Last name" +
                                "\n 3. Address\n 4. City\n 5. State\n 6. Zipcode\n 7. Phone number\n 8. Email ID" +
                                "\n 9. Exit editor");
                            int key = Convert.ToInt32(Console.ReadLine());
                            switch (key)
                            {
                                case 1:
                                    Console.Write("Enter the new First name: ");
                                    contact.firstName = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.Write("Enter the new Last name: ");
                                    contact.lastName = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Write("Enter the new address: ");
                                    contact.address = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Write("Enter the new city: ");
                                    contact.city = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.Write("Enter the new state: ");
                                    contact.state = Console.ReadLine();
                                    break;
                                case 6:
                                    Console.WriteLine("Enter the new zip code: ");
                                    contact.ZipCode = Console.ReadLine();
                                    break;
                                case 7:
                                    Console.WriteLine("Enter the new phone: ");
                                    contact.PhoneNumber = Console.ReadLine();
                                    break;
                                case 8:
                                    Console.Write("Enter the new E-Mail ID: ");
                                    contact.eMail = Console.ReadLine();
                                    break;
                                case 9:
                                    flag = 1;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid input");
                                    EditContact();
                                    break;
                            }
                            if (flag == 1)
                            {
                                break;
                            }
                        }
                        Console.WriteLine("{0}'s contact has been sucessfully updated", editKey);
                        break;
                    }
                }
                if (flag == 0)
                {

                    Console.WriteLine("contact of the person {0} does not exist", editKey);
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
        }
        public static void DeleteContact()
        {
            Console.Write("Enter the name of the addressbook that you wants to use for Deleting contacts: ");
            string addressBookName = Console.ReadLine();
            Console.Write("Enter the first name of the person whose contact you want to delete from the addressbook: ");
            string deleteKey = Console.ReadLine();
            int flag = 0;
            if (myDictAddress[addressBookName].Count > 0)
            {
                foreach (Contacts contact in myDictAddress[addressBookName])
                {
                    if (deleteKey.ToLower() == contact.firstName.ToLower())
                    {
                        flag = 1;
                        addressBook.Remove(contact);
                        break;
                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("Your address book is empty");
            }
            if (flag == 0)
            {

                Console.WriteLine("contact of the person {0} does not exist", deleteKey);
            }
        }

        public static void PersonSearch()
        {
            Dictionary<string, List<Contacts>> cityPersons = new Dictionary<string, List<Contacts>>();
            Dictionary<string, List<Contacts>> statePerson = new Dictionary<string, List<Contacts>>();

            Console.Write("Enter the city that you want to search: ");
            string cityKey = Console.ReadLine();
            cityPersons[cityKey] = new List<Contacts>();
            Console.Write("Enter the state that you want to search: ");
            string stateKey = Console.ReadLine();
            statePerson[stateKey] = new List<Contacts>();
            foreach (string addressBookName in myDictAddress.Keys)
            {
                foreach (Contacts contact in myDictAddress[addressBookName])
                {
                    if (cityKey.ToLower() == contact.city)
                    {
                        cityPersons[cityKey].Add(contact);
                    }
                    else if (stateKey.ToLower() == contact.state)
                    {
                        statePerson[stateKey].Add(contact);
                    }
                }
            }
            PersonSearchDisplay(cityPersons, statePerson, cityKey, stateKey);
        }

        public static void PersonSearchDisplay(Dictionary<string, List<Contacts>> cityPersons, Dictionary<string, List<Contacts>> statePersons, string cityKey, string stateKey)
        {
            Console.WriteLine("------------------- Persons in {0} city-------------------------", cityKey);
            foreach (Contacts contact in cityPersons[cityKey])
            {
                Console.WriteLine("{0}", contact.firstName);
            }
            Console.WriteLine("Total count of persons in the city {0} is {1}", cityKey, cityPersons[cityKey].Count);
            Console.WriteLine("--------------------Persons in {0} state", stateKey);
            foreach (Contacts contact in statePersons[stateKey])
            {
                Console.WriteLine("{0}", contact.firstName);
            }
            Console.WriteLine("Total count of persons in the state {0} is {1}", stateKey, statePersons[stateKey].Count);
        }

        public static void SortEntriesAlphabetically()
        {
            Console.Write("Enter the name of address book you want to sort: ");
            string addressBookName = Console.ReadLine();
            Console.WriteLine();

            if (myDictAddress.ContainsKey(addressBookName))
            {
                myDictAddress[addressBookName].Sort((x,y) => x.firstName.CompareTo(y.firstName));
                ContactsDisplay();
            }
            else
            {
                Console.WriteLine("This address book doesn't exists in our record.");
            }
        }
    }
}
