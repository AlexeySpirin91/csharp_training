using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using addressbook_test;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];

            List<Form> forms = new List<Form>();
            List<Contact> contacts = new List<Contact>();

            if(type == "group")
            {
                for (int i = 0; i < count; i++)
                {
                    forms.Add(new Form(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10)));
                }

                if (format == "excel")
                {
                    WriteGroupsToExcelFile(forms, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]);
                    if (format == "csv")
                    {
                        WriteGroupsToCsvFile(forms, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteGroupsToXmlFile(forms, writer);
                    }
                    else if (format == "json")
                    {
                        WriteGroupsToJsonlFile(forms, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format: " + format);
                    }
                    writer.Close();
                }
            }
            else if(type == "contacts")
            {
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new Contact(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10),
                        TestBase.GenerateRandomString(10)));
                }

                if (format == "excel")
                {
                    WriteContactsToExcelFile(contacts, filename);
                }
                else
                {
                    StreamWriter writer = new StreamWriter(args[2]);
                    if (format == "csv")
                    {
                        WriteContactsToCsvFile(contacts, writer);
                    }
                    else if (format == "xml")
                    {
                        WriteContactsToXmlFile(contacts, writer);
                    }
                    else if (format == "json")
                    {
                        WriteContactsToJsonlFile(contacts, writer);
                    }
                    else
                    {
                        System.Console.Out.Write("Unrecognized format: " + format);
                    }

                    writer.Close();
                }
            }
            else
            {
                System.Console.Out.Write("Unrecognized type: " + type);
            }
        }

        private static void WriteGroupsToExcelFile(List<Form> forms, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;

            int row = 1;
            foreach (Form form in forms)
            {
                sheet.Cells[row, 1] = form.Name;
                sheet.Cells[row, 2] = form.Header;
                sheet.Cells[row, 3] = form.Footer;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));

            wb.Close();
            app.Visible = false;
        }
        static void WriteGroupsToCsvFile(List<Form> forms, StreamWriter writer)
        {
            foreach(Form form in forms)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    form.Name, form.Header, form.Footer));
            }
        }
        static void WriteGroupsToXmlFile(List<Form> forms, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Form>)).Serialize(writer, forms);
        }

        static void WriteGroupsToJsonlFile(List<Form> forms, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(forms, Newtonsoft.Json.Formatting.Indented));
        }


        static void WriteContactsToCsvFile(List<Contact> contacts, StreamWriter writer)
        {
            foreach (Contact contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    contact.Firstname, contact.Lastname, contact.MobilePhone));
            }
        }
        static void WriteContactsToXmlFile(List<Contact> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<Contact>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonlFile(List<Contact> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
        private static void WriteContactsToExcelFile(List<Contact> contacts, string filename)
        {
            Excel.Application app = new Excel.Application();
            app.Visible = true;
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet = (Excel.Worksheet)wb.ActiveSheet;

            int row = 1;
            foreach (Contact contact in contacts)
            {
                sheet.Cells[row, 1] = contact.Firstname;
                sheet.Cells[row, 2] = contact.Lastname;
                sheet.Cells[row, 3] = contact.MobilePhone;
                row++;
            }

            string fullPath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullPath);
            wb.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), filename));

            wb.Close();
            app.Visible = false;
        }
    }
}