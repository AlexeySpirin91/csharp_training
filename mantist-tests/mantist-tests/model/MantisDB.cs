﻿using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToDB;

namespace mantis_tests
{
	public class MantisDB:LinqToDB.Data.DataConnection
	{
		public MantisDB(): base(ProviderName.MySql, @"server=localhost; database=bugtracker; port = 3306; Uid=root;Pwd=;charset=utf8; Allow Zero Datetime = true") { }

		public ITable<ProjectData> Projects { get { return this.GetTable<ProjectData>(); } }
    }
}

