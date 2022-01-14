using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    static class Helpers
    {


        public static void WriteLog(string strLog)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string logFile = Path.Combine(currentDirectory, @"..\Debug\Logs\Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt");
            string logFilePath = Path.GetFullPath(logFile);
            FileInfo logFileInfo = new FileInfo(logFilePath);
            DirectoryInfo logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            using (FileStream fileStream = new FileStream(logFilePath, FileMode.Append))
            {
                using (StreamWriter log = new StreamWriter(fileStream))
                {
                    log.WriteLine(System.DateTime.Now.ToString("yyyy/MM/dd - HH:mm:ss.fff") +" "+strLog);
                }
            }
        }

        public static void ImplicitWait(IWebDriver driver,int seconds)
        {
            
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void Click(IWebDriver driver,string element, string path)
        {

           switch (element.ToLower())
            {
                case "cssselector":
                    driver.FindElement(By.CssSelector(path)).Click();
                    break;

                case "xpath":
                    driver.FindElement(By.XPath(path)).Click();
                    break;

                case "linktext":
                    driver.FindElement(By.LinkText(path)).Click();
                    break;

                case "id":
                    driver.FindElement(By.Id(path)).Click();
                    break;

                case "name":
                    driver.FindElement(By.Name(path)).Click();
                    break;

                case "classname":
                    driver.FindElement(By.ClassName(path)).Click();
                    break;

                case "tagname":
                    driver.FindElement(By.TagName(path)).Click();
                    break;


                default:
                    Helpers.WriteLog("Case not found");
                    break;
            }
        }
    }
}
