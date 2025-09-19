using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selenium
{

    public class RahulShettyFormFill()
    {
        IWebDriver driver;
        [SetUp]
        public void SetupBrowser()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        [Test]
        public void LoginForm()
        {
            driver.FindElement(By.Name("username")).SendKeys("rahulshettyacademy");
            Thread.Sleep(2000);
            driver.FindElement(By.Name("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("karthickselva");
            driver.FindElement(By.Id("password")).SendKeys("learning");
            driver.FindElement(By.Id("signInBtn")).Click();
            //Thread.Sleep(2000); ==> replaced with explicite Wait
          
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//input[@value='Sign In']")));

            //Validate Error msg  
            IWebElement errorEle = driver.FindElement(By.XPath("//div[@class='alert alert-danger col-md-12']"));
            String error = errorEle.Text;
            TestContext.Progress.WriteLine(error);
            String expError = "username/password.";
            Assert.That(error, Does.Contain(expError));

            //Validate Link url
            String attr = driver.FindElement(By.XPath("//a[contains(text(),'Free Access to InterviewQues/ResumeAssistance/Material')]")).GetAttribute("href");
            TestContext.Progress.WriteLine(attr);
            String expAttr = "https://rahulshettyacademy.com/documents-request";
            Assert.AreEqual(expAttr, attr);
            Assert.That(attr, Does.Contain(expAttr));
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(2000);
            driver.Close();
        }
    }
}