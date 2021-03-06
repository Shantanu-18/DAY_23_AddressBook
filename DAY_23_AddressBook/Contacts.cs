using System;
using System.Collections.Generic;
using System.Text;

namespace DAY_23_AddressBook
{
    [Serializable]
    class Contacts
    {
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string ZipCode { get; set; }

        public string PhoneNumber { get; set; }

        public string eMail { get; set; }

    }
}
