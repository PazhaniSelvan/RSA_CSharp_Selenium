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
    public class RahulShettyFormFill1
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
        public void Dropdonwn()
        {
            IWebElement dd = driver.FindElement(By.XPath("//Select[@class='form-control']"));
            SelectElement select = new SelectElement(dd);
            select.SelectByText("Consultant");
            TestContext.Progress.WriteLine(select.SelectedOption);
            Thread.Sleep(3000);
            select.SelectByText("Teacher");
            IList<IWebElement> WE = select.AllSelectedOptions; 
            foreach (IWebElement selopt in WE)
            {
                TestContext.Progress.WriteLine("*****************************");
                Assert.AreEqual("Teacher", selopt.Text);
                if (selopt.Text.Equals("Teacher"))
                {
                    TestContext.Progress.WriteLine("Pass");
                    TestContext.Progress.WriteLine("**********Inside If cluas*********");
                }
            }
        }
        [Test]
        public void RadioButton()
        {
            driver.FindElement(By.XPath("//span[@class='checkmark']/parent::label/span[contains(text(),'User')]")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("okayBtn")));
            driver.FindElement(By.XPath("//button[@id='okayBtn']")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.Id("terms")).Click();
        }

        [TearDown]
        public void CloseBrowser()
        {
            Thread.Sleep(3000);
            driver.Close();
        }

    }
}
