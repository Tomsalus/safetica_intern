using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test
{
    class Teams
    {
        string emailName = "dlp.automation3@safeticadlptesting.onmicrosoft.com";
        string passwordLogin = "Password.dlp";
        string passwordInput = "passwd";
        string loginInput = "loginfmt";
        string noBtnSkip = "idBtn_Back";
        string desktopBtn = "//*[@id='download-desktop-page']/div/a";
        string attachBtn = "//button[@title = 'Attach']";
        string oneDrive = "body > div.popover.ts-file-command-container.am-fade.split-dialog.right > div > files-with-navigation > div > files-navigation > div > ul > ul > li.files-navigation-item.option-top-border > button";
        string wordBtn = "WordFile.docx";
        string uploadBtn = "body > div.popover.ts-file-command-container.am-fade.split-dialog.right > div > files-with-navigation > div > div > div.flex-fill.button-pane.flex-fill-row.filesButtonContainer > div > div:nth-child(2) > button";
        string popupWin = "#files-name-collision-dialog > div > div";
        string replaceBtn = "#files-name-collision-dialog > div > div > div.ts-modal-dialog-footer > div.ts-modal-dialog-footer-buttons > div:nth-child(3) > button";
        string chat = "//*[@id='cke_1_contents']/div";
        string testChannel = "a[title='Test']";
        string newConversation = "#new-post-button";

        public IWebDriver WebDriver { get; set; }
        public Teams(IWebDriver driver)
        {
            WebDriver = driver;
        }

        public void TeamsUrl()
        { 
            Helpers.WriteLog("");
            Helpers.WriteLog("*************************************************");
            Helpers.WriteLog("Setting up a test");
            Helpers.WriteLog("*************************************************");
            Helpers.WriteLog("Starting a driver");
            WebDriver.Manage().Window.Maximize();
            WebDriver.Navigate().GoToUrl("https://teams.microsoft.com/");
            Helpers.WriteLog("Executing GoToUrl https://teams.microsoft.com/ ");
            //Assert.AreEqual("Sign in to your account", WebDriver.Title);
            //Helpers.WriteLog("Checking the title");
        }

        public void LogIn()
        {
            Helpers.ImplicitWait(WebDriver,10);
            IWebElement email = WebDriver.FindElement(By.Name(loginInput));
            Helpers.WriteLog("Looking for element");
            email.SendKeys(emailName);
            email.SendKeys(Keys.Enter);
            Helpers.WriteLog("Entering E-mail");
            Thread.Sleep(1000);
            Helpers.WriteLog("Looking for element");
            IWebElement password = WebDriver.FindElement(By.Name(passwordInput));
            password.SendKeys(passwordLogin);
            password.SendKeys(Keys.Enter);
            Helpers.WriteLog("Entering password");
            Thread.Sleep(1000);
            Helpers.WriteLog("Looking for element");
            Helpers.ImplicitWait(WebDriver,10);
            Helpers.Click(WebDriver,"id", noBtnSkip);
            Helpers.WriteLog("Skipping 'Stay signed in'");
            Thread.Sleep(1000);
            /*Helpers.WriteLog("Looking for element");
            Helpers.Click(WebDriver,"XPAth", desktopBtn);
            Helpers.WriteLog("Opening web app");*/
        }

        public void NewConversation()
        {
            Helpers.WriteLog("Looking for element");
            Helpers.ImplicitWait(WebDriver, 20);
            Helpers.Click(WebDriver, "cssselector", newConversation);
            Helpers.WriteLog("Creating new conversation");
        }

        public void UploadFile()
        {
            Helpers.WriteLog("Looking for element");
            Helpers.ImplicitWait(WebDriver,10);
            Helpers.Click(WebDriver,"xpath", attachBtn);   
            Helpers.WriteLog("Trying to attach a file");
            Helpers.WriteLog("Looking for element");
            Helpers.WriteLog("Selecting OneDrive Option");
            Thread.Sleep(500);
            Helpers.ImplicitWait(WebDriver,20);
            Helpers.Click(WebDriver,"CSSSelector", oneDrive);
            Helpers.WriteLog("Looking for element");
            Helpers.WriteLog("Selecting Document");
            Helpers.ImplicitWait(WebDriver,10);
            Helpers.Click(WebDriver,"linktext", wordBtn);
            Helpers.WriteLog("Looking for element");
            Helpers.WriteLog("Uploading the file");
            Helpers.ImplicitWait(WebDriver,10);
            Helpers.Click(WebDriver,"Cssselector", uploadBtn);     
        }

        public void CheckIfAlreadyUploaded()
        {
            Helpers.ImplicitWait(WebDriver, 15);
            if (WebDriver.FindElement(By.CssSelector(popupWin)).Displayed)
            {
                Helpers.WriteLog("File already uploaded");
                Helpers.WriteLog("Trying to replace the file");
                Helpers.ImplicitWait(WebDriver,10);
                Helpers.Click(WebDriver,"cssselector", replaceBtn);
                Helpers.WriteLog("Replacing the file");
                Thread.Sleep(5000);
                IWebElement enter = WebDriver.FindElement(By.XPath(chat));
                enter.SendKeys(Keys.Enter);
            }
            else
            {
                Thread.Sleep(3000);
                IWebElement enter = WebDriver.FindElement(By.XPath(chat));
                enter.SendKeys(Keys.Enter);               
            }
        }

        public void ChangeChannel()
        {
            Helpers.WriteLog("Looking for element");
            Helpers.WriteLog("Changing a channel");
            Helpers.ImplicitWait(WebDriver,10);
            Helpers.Click(WebDriver,"cssselector", testChannel);
        }

        public void TypeMessage()
        {
            Helpers.WriteLog("Looking for element");
            IWebElement message = WebDriver.FindElement(By.XPath(chat));
            Helpers.WriteLog("Entering message");
            message.SendKeys("AAA");
            Helpers.ImplicitWait(WebDriver, 1);
            message.SendKeys(Keys.Enter);
        }

       
    }
}
