using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class WebTable
    {
        IWebDriver driver;
        [SetUp]
        public void SetupBrowser()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            //driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/";
            driver.Url = "https://rahulshettyacademy.com/seleniumPractise/#/offers";
        }

        [Test]
        public void WebTableTest()
        {
            ArrayList  ar = new ArrayList ();

            //driver.FindElement(By.LinkText("Top Deals")).Click();
            SelectElement select = new SelectElement(driver.FindElement(By.Id("page-menu")));
            select.SelectByText("20");
            IList<IWebElement> vegies = driver.FindElements(By.XPath("//tr//td[1]"));

            foreach (IWebElement vegie in vegies)
            { 
                ar.Add(vegie.Text);
            }
            
            ar.Sort();
            TestContext.Progress.WriteLine("After Sort");
           
            foreach (String ele in ar)
            {
                TestContext.Progress.WriteLine(ele);
            }

            //after sorting get the elements in ar list and compare
            driver.FindElement(By.XPath("//span[contains(text(),'Veg/fruit name')]")).Click();

            ArrayList ar1 = new ArrayList();
            IList<IWebElement> Sortedvegies = driver.FindElements(By.XPath("//tr//td[1]"));
            foreach (IWebElement SortedVegie in Sortedvegies)
            {
                ar1.Add(SortedVegie.Text);
            }

            foreach (String ele1 in ar1)
            {
                TestContext.Progress.WriteLine(ele1);
            }

            Assert.AreEqual(ar, ar1);
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(3000);
            driver.Close();
        }



    }
}
