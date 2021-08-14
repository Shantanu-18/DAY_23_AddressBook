using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DAY_23_AddressBook
{
    class BinaryDeserialization
    {
        public static Dictionary<string, List<Contacts>> Deserialization()
        {
            Dictionary<string, List<Contacts>> MySystem = new Dictionary<string, List<Contacts>>();
            FileStream fileStream = new FileStream(@"E:\FellowShip\DAY_23_AddressBook\DAY_23_AddressBook\AddressBook.txt", FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            MySystem = (Dictionary<string, List<Contacts>>)binaryFormatter.Deserialize(fileStream);
            fileStream.Close();

            return MySystem;

        }
    }
}
