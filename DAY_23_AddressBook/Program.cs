using System;

namespace DAY_23_AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Address Book System");
            AddressBook obj = new AddressBook();


            while (true)
            {
                Console.WriteLine("1. Add member to Contact list \n2. View Members in Contact List" +
                                                  "\n3. Edit Contact\n4. Delete Contact\n5. Exit");
                Console.Write("Enter an option:");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        obj.AddMember();
                        break;
                        
                    case 2:
                        obj.ViewContacts();
                        break;
                       
                    case 3:
                        obj.EditDetails();
                        break;
                        
                    case 4:
                        obj.DeleteDetails();
                        break;
                       

                    case 5:
                        Console.WriteLine("Exited");
                        return;

                }
            }
        }
    }
}
