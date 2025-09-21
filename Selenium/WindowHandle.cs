using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    public class WindowHandle
    {
        IWebDriver driver;
        String US; // class variable is defaulted to null, can be used without initialization

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

        /*
        [Test]
        public void WindowHandles()
        {
            String parentWindow = driver.CurrentWindowHandle;
            TestContext.Progress.WriteLine("MainWindow :" + parentWindow);
            Thread.Sleep(3000);
            driver.FindElement(By.PartialLinkText("Free Access to InterviewQues")).Click();
            IList<String> mulWindow = driver.WindowHandles;
            TestContext.Progress.WriteLine(mulWindow.Count);
            TestContext.Progress.WriteLine("MainWindow :" + driver.Title + mulWindow[0]);
            
            TestContext.Progress.WriteLine("ChildWindow :" + driver.Title + mulWindow[1]);
            
            Assert.AreEqual(parentWindow, mulWindow[0]);
        }
        */

        [Test]
        public void SwitchingBetweenWindows()
        {
            String email = "mentor@rahulshettyacademy.com";
            //String US ; // local avriable should be initialized before use, it is not defaulted to null
            String parentWindow = driver.CurrentWindowHandle;
            IWebElement ele = driver.FindElement(By.PartialLinkText("Free Access to InterviewQues"));
            
            ele.Click();
            IList<String> mulWindow = driver.WindowHandles;
            driver.SwitchTo().Window(mulWindow[1]);
            String value = driver.FindElement(By.XPath("//p[text()=\"Please email us at \"]")).Text;
            String[] valueArray = value.Split(" ");
            foreach (String va in valueArray)
            {
                if (va == email)
                {
                    US = va;
                    TestContext.Progress.WriteLine(US);
                    break;
                }
            }
            driver.SwitchTo().Window(parentWindow);
            TestContext.Progress.WriteLine(US);
            driver.FindElement(By.Id("username")).SendKeys(US);
            Thread.Sleep(5000);
            //String currentWindow = driver.Url;  
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}
