﻿using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace addressbook_test
{

    [TestFixture]
    public class CreateContact : ContactTestBase
    {

        public static IEnumerable<Contact> RandomContactDataProvider()
        {
            List<Contact> contact = new List<Contact>();
            for (int i = 0; i < 5; i++)
            {
                contact.Add(new Contact (GenerateRandomString(10), GenerateRandomString(15)));
            }
            return contact;
            ;
        }

        public static IEnumerable<Contact> ContactDataFromXmlFile()
        {
            return (List<Contact>)
                new XmlSerializer(typeof(List<Contact>))
                .Deserialize(new StreamReader(@"contacts.xml"));

        }

        public static IEnumerable<Contact> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<Contact>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void TheContactTest(Contact contact)
        {

            List<Contact> oldContacts = Contact.GetAll();
            app.Navigator.GoToContactPage();
            app.Contacts
                .FillContactInfo(contact.Firstname, contact.Lastname)
                .ClickEnter();
            List<Contact> newContacts = Contact.GetAll();
            oldContacts.Add(contact);

            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.GoToHomePage();
        }

    }

}