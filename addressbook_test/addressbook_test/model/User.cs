using System;
namespace addressbook_test
{
    class User
    {
        private string login;
        private string pass;
        public User(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }
        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
            }
        }
        public string Pass
        {
            get
            {
                return pass;
            }
            set
            {
                login = pass;
            }
        }
    }


}