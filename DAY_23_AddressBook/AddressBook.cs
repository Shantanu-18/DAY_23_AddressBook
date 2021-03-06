using System;
using System.Collections.Generic;
using System.Text;

namespace DAY_23_AddressBook
{
    class AddressBook
    {
        public static Dictionary<string, List<Contacts>> myDictAddress = new Dictionary<string, List<Contacts>>();
        public static List<Contacts> addressBook;

        public static void Serializepass()
        {
            BinarySerializations.Serializations(myDictAddress);
        }
        public static void DeserializePass()
        {
            Dictionary<string, List<Contacts>> myDictAddressCopy = BinaryDeserialization.Deserialization();
            myDictAddress.Clear();
            foreach (string key in myDictAddressCopy.Keys)
            {
                myDictAddress.Add(key, myDictAddressCopy[key]);
            }
            myDictAddressCopy.Clear();
        }

        public static void addressBookNewExisting()
        {
            Console.WriteLine("Enter a input\n" +
                "1. New addresbook\n" +
                "2. Existing addressbook");
            int key = Convert.ToInt32(Console.ReadLine());
            if (key == 1)
            {
                addAddressBook();
            }
            else if (key == 2)
            {
                ExistingNameAddressBookValidator();
            }
        }

        public static void addAddressBook()
        {
            Console.Write("How many addressbooks do you want to create?");
            int count = Convert.ToInt32(Console.ReadLine());
            while (count > 0)
            {
                NewNameAddressBookValidator();
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

        public static void AddressBookDisplay()
        {
            if (myDictAddress.Count > 0)
            {
                Console.Write("Enter the name of the addressbook that you wants to use for displaying contacts: ");
                string addressBookName = Console.ReadLine();
                if (myDictAddress[addressBookName].Count > 0)
                {
                    foreach (Contacts contact in myDictAddress[addressBookName])
                    {
                        Console.WriteLine("First name-->{0}", contact.firstName);
                        Console.WriteLine("Last name-->{0}", contact.lastName);
                        Console.WriteLine("Address-->{0}", contact.address);
                        Console.WriteLine("City-->{0}", contact.city);
                        Console.WriteLine("State-->{0}", contact.state);
                        Console.WriteLine("Zip code-->{0}", contact.ZipCode);
                        Console.WriteLine("Phone number-->{0}", contact.PhoneNumber);
                        Console.WriteLine("E-Mail ID-->{0}", contact.eMail);
                    }
                }
                else
                {
                    Console.WriteLine("Your address book is empty");
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }

        public static void ContactsDisplay()
        {
            if (myDictAddress.Count > 0)
            {
                Console.Write("Enter the name of the addressbook that you wants to use for displaying contacts: ");
                string addressBookName = Console.ReadLine();
                if (myDictAddress[addressBookName].Count > 0)
                {
                    Console.WriteLine("Enter the name of the person to get all the contact details");
                    string nameKey = Console.ReadLine();
                    int flag = 0;
                    foreach (Contacts contact in myDictAddress[addressBookName])
                    {
                        if (nameKey.ToLower() == contact.firstName.ToLower())
                        {
                            flag = 1;
                            Console.WriteLine("First name-->{0}", contact.firstName);
                            Console.WriteLine("Last name-->{0}", contact.lastName);
                            Console.WriteLine("Address-->{0}", contact.address);
                            Console.WriteLine("City-->{0}", contact.city);
                            Console.WriteLine("State-->{0}", contact.state);
                            Console.WriteLine("Zip code-->{0}", contact.ZipCode);
                            Console.WriteLine("Phone number-->{0}", contact.PhoneNumber);
                            Console.WriteLine("E-Mail ID-->{0}", contact.eMail);
                            break;
                        }
                    }
                    if (flag == 0)
                    {
                        Console.WriteLine("contact of the person {0} does not exist", nameKey);
                    }
                }
                else
                {
                    Console.WriteLine("Your address book is empty");
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
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
            Console.WriteLine("------------------ Persons in {0} city ------------------", cityKey);
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
                AddressBookDisplay();
            }
            else
            {
                Console.WriteLine("This address book doesn't exists in our record.");
            }
        }

        public static void AddressBookSorting()
        {
            if (myDictAddress.Count > 0)
            {
                Console.WriteLine("Enter the addressbook name that you want to sort it");
                string addressBookName = Console.ReadLine();

                if (myDictAddress.ContainsKey(addressBookName))
                {
                    SortBy(addressBookName);
                }
                else
                {
                    Console.WriteLine("The given addressbook does not exist. please enter a valid addressbook  name");
                    AddressBookSorting();
                }
            }
            else
            {
                Console.WriteLine("You don't have any addressbook");
            }
        }

        public static void SortBy(string addressBookName)
        {
            Console.WriteLine("How do you want the addressbook to be sorted?\n Enter\n1 to sort based on City\n2 to sort based on State\n3 to sort based on Zipcode");
            switch (Console.ReadLine())
            {
                case "1":
                    myDictAddress[addressBookName].Sort((x, y) => x.city.CompareTo(y.city));
                    Console.WriteLine("Sorted by City");
                    break;
                case "2":
                    myDictAddress[addressBookName].Sort((x, y) => x.state.CompareTo(y.state));
                    Console.WriteLine("Sorted by State");
                    break;
                case "3":
                    myDictAddress[addressBookName].Sort((x, y) => x.ZipCode.CompareTo(y.ZipCode));
                    Console.WriteLine("Sorted by ZipCode");
                    break;
            }
        }
    }
}
