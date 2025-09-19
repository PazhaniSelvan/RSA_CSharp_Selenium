using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{
    public class AddItemsToCart
    {
        IWebDriver driver;
        [SetUp]
        public void SetupBrowser()
        {

            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void AddItestocart()
        {
            String[] ExpProducts = { "iphone X", "Blackberry" };

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();

            //Locator of cart button
            By cartBtn = By.ClassName("btn-primary");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(cartBtn));


            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement prod in products)
            {
                //narrow down to particular product , hence using prod instead of driver
                String text = prod.FindElement(By.ClassName("card-title")).Text;
                TestContext.Progress.WriteLine(text);
                if (ExpProducts.Contains(text))
                { 
                    prod.FindElement(By.XPath("//button[text()='Add ']")).Click();
                    
                }
               
            }
            driver.FindElement(cartBtn).Click();

        }


        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(3000);
            driver.Close();
        }

    }
}
