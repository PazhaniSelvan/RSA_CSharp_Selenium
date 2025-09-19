using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;

namespace Selenium
{
    public class SeleniumFirst()
    {
        IWebDriver driver;

        [SetUp]
        public void SetupBrowser()
        {
            //adding below code and package in an optional as latest version of selenium web driver is having inbuilt driver manager
            //new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            //driver = new FiserfoxDriver();
            //driver = new EdgeDriver();
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

        }

        [Test]
        public void Test1()
        {
            //https://rahulshettyacademy.com/loginpagePractise/
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
            TestContext.Progress.WriteLine(driver.Url);
            TestContext.Progress.WriteLine(driver.Title);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}
