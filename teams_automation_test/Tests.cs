using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Test
{
    [TestFixture("Chrome")]
    [TestFixture("FireFox")]
    class Tests : CommonTest
    {
        private string browser;
        IWebDriver driver;

        public Tests(string browser)
        {
            this.browser = browser;
        }
 
        [SetUp]
        public void SetUpDriver()
        {
            driver = DriverClass.GetDriver(browser);
        }
        [Test]
        public void Test()
        {
            Teams teams = new Teams(driver);
            teams.TeamsUrl();
            teams.LogIn();
            teams.NewConversation();
            teams.UploadFile();
            teams.CheckIfAlreadyUploaded();
            teams.ChangeChannel();
            teams.NewConversation();
            teams.TypeMessage();    
        }
        [OneTimeTearDown]
        public void BrowserClose()
        {
            driver.Quit();
        }
    }
}
