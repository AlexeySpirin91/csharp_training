using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToDB;

namespace addressbook_test
{
	public class AddressBookDB:LinqToDB.Data.DataConnection
	{
		public AddressBookDB(): base(ProviderName.MySql, @"server=localhost; database=addressbook; port = 3306; Uid=root;Pwd=;charset=utf8; Allow Zero Datetime = true") { }

		public ITable<Form> Forms { get { return this.GetTable<Form>(); } }
        public ITable<Contact> Contacts { get { return this.GetTable<Contact>(); } }

    }
}

