using System;
namespace addressbook_test
{
    public class Form:IEquatable<Form>, IComparable<Form>
    {
        public Form(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
        public string Name { get; set; }
        public string Header { get; set; }
        public string Footer { get; set; }
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
            return "name=" + Name;
        }

        public int CompareTo(Form other)
        {
            if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }
    }


}