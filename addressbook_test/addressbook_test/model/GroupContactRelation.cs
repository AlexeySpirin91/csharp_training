using System;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using LinqToDB.Mapping;

namespace addressbook_test
{
    [Table(Name = "address_in_groups")]
    public class GroupContactRelation
	{
		public GroupContactRelation()
		{
		}
		[Column(Name ="group_id")]
		public string GroupId { get; set; }
        [Column(Name = "id")]
        public string ContactId { get; set; }

	}
}

