using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToDB;

namespace mantist_tests
{
	public class MantistDB:LinqToDB.Data.DataConnection
	{
		public MantistDB(): base(ProviderName.MySql, @"server=localhost; database=bugtracker; port = 3306; Uid=root;Pwd=;charset=utf8; Allow Zero Datetime = true") { }

		public ITable<ProjectData> Projects { get { return this.GetTable<ProjectData>(); } }
    }
}

