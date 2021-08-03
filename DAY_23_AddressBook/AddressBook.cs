using System;
using System.Collections.Generic;
using System.Text;

namespace DAY_23_AddressBook
{
    public class AddressBook
    {
        private static List<Person> contacts = new List<Person>();

        public static void AddMember()
        {
            Person person = new Person();

            Console.Write("Enter First Name: ");
            person.firstName = Console.ReadLine();

            Console.Write("Enter Last Name: ");
            person.lastName = Console.ReadLine();

            Console.Write("Enter Address: ");
            person.address = Console.ReadLine();

            Console.Write("Enter City: ");
            person.city = Console.ReadLine();

            Console.Write("Enter State: ");
            person.state = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter Zip Code of your area: ");
                string code = Console.ReadLine();

                if (code.Length == 6)
                {
                    person.zipCode = Convert.ToInt32(code);
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a valid 6 digit Zip Code.");
                }
            }

            while (true)
            {
                Console.Write("Enter Phone Number: ");
                string phNo = Console.ReadLine();
                if (phNo.Length == 10)
                {
                    person.phoneNumber = phNo;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Phone Number,It should Contain 10 digits");
                }
            }

            while (true)
            {
                Console.Write("Enter Email-id: ");
                string emailId = Console.ReadLine();
                if (emailId.Contains("@"))
                {
                    person.email = emailId;
                    break;
                }
                else
                {
                    Console.WriteLine("Enter Valid Email Id, It should Contains @ ");
                }
            }
            contacts.Add(person);

            Console.WriteLine("Added Successfully");
        }
    }
}