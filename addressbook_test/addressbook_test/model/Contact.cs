using System;
using System.Xml.Linq;

namespace addressbook_test
{
    public class Contact: IEquatable<Contact>, IComparable<Contact>
    {
        private string firstname;
        private string lastname;
        private string mobile;

        public Contact(string firstname, string lastname, string mobile)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.mobile = mobile;
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }
        public string Mobile
        {
            get
            {
                return mobile;
            }
            set
            {
                mobile = value;
            }

        }

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