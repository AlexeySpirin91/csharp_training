using System;
using LinqToDB.Mapping;
namespace addressbook_test
{
    [Table(Name = "group_list")]
    public class Form : IEquatable<Form>, IComparable<Form>
    {
        public Form() { }
        public Form(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
        [Column(Name = "group_name")]
        public string Name { get; set; }
        [Column(Name = "group_header")]
        public string Header { get; set; }
        [Column(Name = "group_footer")]
        public string Footer { get; set; }
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public bool Equals(Form other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name=" + Name + "\\nheader= " + Header + "\\nfooter" + Footer;
        }

        public int CompareTo(Form other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<Form> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from f in db.Forms select f).ToList();
            }
        }

        public static List<string> GetAllNames()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from f in db.Forms select f.Name).ToList();
            }
        }

        public List<Contact> GetContacts()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from c in db.Contacts
                        from gcr in db.GCR.Where(p=> p.GroupId == Id && p.ContactId == c.Id && c.Deprecated == "0000-00-00 00:00:00")
                        select c).Distinct().ToList();
            }
        }
    }


}