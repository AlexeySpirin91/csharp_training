using System;
using System.Xml.Linq;

namespace addressbook_test
{
    public class Contact
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
    }


}