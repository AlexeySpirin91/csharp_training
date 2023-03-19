using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToDB.Mapping;

namespace addressbook_test
{
    [Table(Name = "addressbook")]
    public class Contact: IEquatable<Contact>, IComparable<Contact>
    {
        private string allPhone;
        private string allEmail;
        private string alldata;
        private string address;

        public Contact() { }
        public Contact(string firstname, string lastname,string mobilePhone)
        {
            Firstname = firstname;
            Lastname = lastname;
            MobilePhone = mobilePhone;
        }

        public Contact(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        [Column(Name = "firstname")]
        public string Firstname { get; set; }
        [Column(Name = "lastname")]
        public string Lastname { get; set; }
        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }
        public string Address
        {
            get
            {
                if (address == "") { return ""; }
                else { return address + "\n"; }
            }
            set
            {
                address = value;
            }
        }
        
        public string AllPhone {
            get
            {
                if(allPhone == ""){ return ""; }
                else if (allPhone != null) { return allPhone + "\n\n"; }
                {
                    return (CleanUp(HomePhone) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + "\n").Trim();
                }

            }
            set
            {
                allPhone = value;
            }
        }
        public string HomePhone { get; set; }
        [Column(Name = "mobile")]
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

        [Column(Name ="deprecated")]
        public string Deprecated { get; set; }

        private string CleanUp(string phone)
        {
            if (phone == null || phone =="")
                return "";
            return Regex.Replace(phone, "[ -()]", "") + "\n";
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

                public static List<Contact> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts.Where(x=> x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }

    }


}