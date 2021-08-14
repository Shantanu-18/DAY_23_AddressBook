using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DAY_23_AddressBook
{
    class BinarySerializations
    {
        public static void Serializations(Dictionary<string, List<Contacts>> mySystem)
        {
            FileStream fileStream = new FileStream(@"E:\FellowShip\DAY_23_AddressBook\DAY_23_AddressBook\AddressBook.txt", FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(fileStream, mySystem);
            fileStream.Close();
        }
    }
}
