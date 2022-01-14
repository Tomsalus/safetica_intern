using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    public class CommonTest
    {
        
        

        [SetUp]
        public void SetUp()
        {
            


            Helpers.WriteLog("");
            Helpers.WriteLog("*************************************************");
            Helpers.WriteLog("Starting a test");
            Helpers.WriteLog("*************************************************");
        }


        [TearDown]
        public void TearDown()
        {
            Helpers.WriteLog("*************************************************");
            Helpers.WriteLog("Test FINISHED");
            Helpers.WriteLog("*************************************************");
        }
        


        
    }
}
