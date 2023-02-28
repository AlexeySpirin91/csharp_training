using System;
using System.Xml.Linq;

namespace addressbook_test
{
    public class Contact: IEquatable<Contact>, IComparable<Contact>
    {

        public Contact(string firstname, string lastname, string mobile)
        {
            Firstname = firstname;
            Lastname = lastname;
            Mobile = mobile;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Mobile { get; set; }

        public bool Equals(Contact other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return Firstname == other.Firstname
                && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return (Lastname+Firstname).GetHashCode();
        }

        public override string ToString()
        {
            return Lastname + Firstname;
        }

        public int CompareTo(Contact other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return (Firstname+Lastname).CompareTo(other.Firstname+other.Lastname);
        }

    }


}