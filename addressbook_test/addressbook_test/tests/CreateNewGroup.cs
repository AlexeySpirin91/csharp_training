using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Linq;
using NUnit.Framework;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace addressbook_test
{
    [TestFixture]
    public class GroupCreateTest : GroupTestBase
    {
        public static IEnumerable<Form> RandomGroupDataProvider()
        {
            List<Form> groups = new List<Form>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(new Form(GenerateRandomString(50), GenerateRandomString(60), GenerateRandomString(30)));
            }
            return groups;
            ; }

        public static IEnumerable<Form> GroupDataFromCsvFile()
        {
            List<Form> groups = new List<Form>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new Form(parts[0], parts[1], parts[2]));
            }

            return groups;
        }

        public static IEnumerable<Form> GroupDataFromXmlFile()
        {
            return (List<Form>)
                new XmlSerializer(typeof(List<Form>))
                .Deserialize(new StreamReader(@"groups.xml"));
        }

        public static IEnumerable<Form> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Form>>(
                File.ReadAllText(@"groups.json"));
        }


        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreateTests(Form form)
        {

            app.Navigator.GoToGroupsPage();
            List<Form> oldGroups = Form.GetAll();
            app.Groups.Create(form.Name, form.Header, form.Footer);

            List<Form> newGroups = Form.GetAll();
            oldGroups.Add(form);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Navigator.GoToHomePage();
        }

        [Test]
        public void TestDBConnectivity()
        {
            foreach (Contact contact in Contact.GetAll())
            {
                System.Console.Out.WriteLine(contact.Deprecated);
            }

        }

    }

}