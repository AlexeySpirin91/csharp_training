using System;
using LinqToDB.Mapping;
using static LinqToDB.Sql;

namespace mantist_tests
{
    [Table(Name = "mantis_project_table")]
    public class ProjectData:IEquatable<ProjectData>,IComparable<ProjectData>
	{
        public ProjectData() { }
        public ProjectData(string name)
        {
            Name = name;
        }
        [Column(Name = "name")]
        public string Name { get; set; }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
                return false;
            if (Object.ReferenceEquals(this, other))
                return true;
            return Name == other.Name;
        }

        public int CompareTo(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<ProjectData> GetProjects()
        {
            using (MantistDB db = new MantistDB())
            {
                return (from p in db.Projects select p).ToList();
            }
        }
    }
}

