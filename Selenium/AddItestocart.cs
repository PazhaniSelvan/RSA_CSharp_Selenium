using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Microsoft.Extensions.Options;
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
            ChromeOptions options = new ChromeOptions();
            // Only affects the Selenium-launched Chrome session
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);
            driver = new ChromeDriver(options);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void AddItestocart()
        {
            String[] ExpProducts = { "iphone X", "Blackberry" };
            String[] ActualProducts = new String[ExpProducts.Length];
            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.Id("terms")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();

            //Locator of cart button
            By cartBtn = By.ClassName("btn-primary");
            Thread.Sleep(10000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(cartBtn));


            IList<IWebElement> products = driver.FindElements(By.TagName("app-card"));
            foreach (IWebElement prod in products)
            {
                //narrow down to particular product , hence using prod instead of driver
                //String text = prod.FindElement(By.ClassName("card-title")).Text;
                
                TestContext.Progress.WriteLine(prod.FindElement(By.ClassName("card-title")).Text);
                if (ExpProducts.Contains(prod.FindElement(By.CssSelector(".card-title a")).Text))
                { 
                    prod.FindElement(By.CssSelector(".card-footer button")).Click();
                    
                }
                TestContext.Progress.WriteLine(prod.FindElement(By.ClassName("card-title")).Text);

            }
            driver.FindElement(cartBtn).Click();

            IList <IWebElement> ItemsCart = driver.FindElements(By.XPath("//h4[@class='media-heading']//a"));

            for (int i = 0; i < ItemsCart.Count; i++)
            {
               ActualProducts[i] = ItemsCart[i].Text;

            }
            driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();
            driver.FindElement(By.XPath("//label[@for='checkbox2']")).Click();
            ////input[@class='btn btn-success btn-lg']
            driver.FindElement(By.ClassName("btn-success")).Click();


        }


        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(3000);
            driver.Close();
        }

    }
}
