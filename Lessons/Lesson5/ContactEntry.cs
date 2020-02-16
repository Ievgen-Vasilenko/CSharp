using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5
{
    class ContactEntry
    {
        public ContactEntry()
        {
            LastName = "";
            FirstName = "";
            PhoneNumber = "";
            Email = "";
        }

        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}; Tel.: {2}; Email: {3}",
                LastName,
                FirstName,
                PhoneNumber,
                Email);
        }
    }
}
