using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace addressbook_test
{
    public class TestBase
    {

        protected ApplicationManager app;

        [SetUp]
        public void SetupTest()
        {
            app = new ApplicationManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            app.Stop();
        }
    }

}