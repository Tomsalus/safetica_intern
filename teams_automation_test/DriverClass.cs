using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class DriverClass
    {


    public enum BrowserType
        {
            IE,
            Chrome,
            FireFox
        }

        

        public static IWebDriver GetDriver(string browser)
        {
            IWebDriver Driver;


            /*switch (browser)
            {
                case "Chrome":
                    Driver = new ChromeDriver();
                    break;

                case "FireFox":
                    var op = new FirefoxOptions
                    {
                        AcceptInsecureCertificates = true
                    };
                    Driver = new FirefoxDriver(op);
                    break;

                case "IE":
                    Driver = new InternetExplorerDriver();
                    break;


                default:
                    Driver = null;
                    break;
            }
            */

            if (browser == "Chrome")
            {
                Driver = new ChromeDriver();
            }
            else if (browser == "FireFox")
            {
                var op = new FirefoxOptions
                {
                    AcceptInsecureCertificates = true
                };
                Driver = new FirefoxDriver(op);
                

            }
            else if (browser == "IE")
            {
                Driver = new InternetExplorerDriver();
            }
            else
            {
                Driver = null;
            }
            
            return Driver;
        }
    }
}
