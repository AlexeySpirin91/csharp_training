using System;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace addressbook_test
{
    public class Contact: IEquatable<Contact>, IComparable<Contact>
    {
        private string allPhone;
        private string allEmail;

        public Contact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }

        public string AllPhone {
            get
            {
                if(allPhone != null) { return allPhone; }
                else
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone)).Trim();
                }

            }
            set
            {
                allPhone = value;
            }
        }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

        public string AllEmail {
            get
            {
                if (allEmail != null) { return allEmail; }
                else
                {
                    return (Email +"\n" + Email2 + "\n" + Email3).Trim();
                }

            }
            set
            {
                allEmail = value;
            }
        }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
                return "";
            return Regex.Replace(phone,"[ -()]", "") +"\n";
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

            if (Lastname == other.Lastname)
            {
                return Firstname.CompareTo(other.Firstname);
            }

            return Lastname.CompareTo(other.Lastname);
        }

    }


}