using AventStack.ExtentReports;
using AventStack.ExtentReports.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Support.UI;

namespace Test.Drivers
{
    public class QsTester
    {
        protected string archivoReportePath;
        private int offsetY;
        private int offsetX;

        public IWebDriver Driver { get; set; }


        public QsTester(IWebDriver Driver)
        {
            this.Driver = Driver;
        }


        public IWebDriver ChromeDriverConnection()
        {
            this.Driver = new ChromeDriver();
            Thread.Sleep(8000);
            return Driver;
        }

        public void Visit(string URL)
        {
            Thread.Sleep(4000);
            Driver.Navigate().GoToUrl(URL);
        }

        public string GetText(By locator)
        {
            return Driver.FindElement(locator).Text;
        }

        public string GetText(IWebElement element)
        {
            return element.Text;
        }

        public IWebElement FindElement(By locator)
        {
            return Driver.FindElement(locator);
        }
     
        public IReadOnlyCollection<IWebElement> FindElements(By locator)
        {
            return Driver.FindElements(locator);
        }

        public void type(string text, By locator)
        {
            Driver.FindElement(locator).SendKeys(text);
        }

        public void click(By locator)
        {
            Driver.FindElement(locator).Click();
        }

        public void Tabulador(By locator)
        {
            Driver.FindElement(locator).SendKeys(Keys.Tab);

        }

        public void submit(By locator)
        {
            Driver.FindElement(locator).Submit();
        }

        public bool isDispalyed(By locator)
        {
            try
            {
                return Driver.FindElement(locator).Displayed;
            }
            catch
            {
                return false;
            }
        }

        public void ExpectedCondition(By locator)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2000));
            IWebElement element = wait.Until(driver => driver.FindElement(locator));
        }

        public void ExpectedDisplay(By locator)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(2000));
            IWebElement element = wait.Until(driver => driver.FindElement(locator));
        }

        public void Close()
        {
            Driver.Close();
            Driver.Dispose();
            Thread.Sleep(4000);
        }

        public void MaxWindow()
        {

            Driver.Manage().Window.Maximize();

        }
        public MediaEntityModelProvider Sshot(string Name)
        {

            var screenshot = ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
            return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, Name).Build();

        }

        public String SshotB64()
        {
            return ((ITakesScreenshot)Driver).GetScreenshot().AsBase64EncodedString;
        }

        public void Consola()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("auto-open-devtools-for-tabs", "true");
        }

        public void SaveScreenShot(string filename)
        {
            var media = SshotB64();
            var bytes = Convert.FromBase64String(media);
            using (var imageFile = new FileStream(filename, FileMode.Create))
            {
                imageFile.Write(bytes, 0, bytes.Length);
                imageFile.Flush();
            }
        }

        public void SelectItemByValue(string value, By locator)
        {
            var combo = this.FindElement(locator);
            var selected = new SelectElement(combo);
            selected.SelectByValue(value);
        }

        public void SelectItemByText(string text, By locator)
        {
            var combo = this.FindElement(locator);
            var selected = new SelectElement(combo);
            selected.SelectByText(text);
        }

        public void scrollDown(string text)
        {
            IJavaScriptExecutor js = Driver as IJavaScriptExecutor;
            js.ExecuteScript("window.scrollBy(0," + text + ");");
        }
        public void Enter(By locator)
        {
            Driver.FindElement(locator).SendKeys(Keys.Enter);
            
        }

        public void Cursor(By locator)
        {
            var element = Driver.FindElement(locator);
            new Actions(Driver).MoveToElement(element).MoveByOffset(offsetX, offsetY).Build().Perform();

        }

        public void Escape(By locator)
        {
            Driver.FindElement(locator).SendKeys(Keys.Escape);

        }
        public void SwitchLocator(By locator)
        {
            Driver.SwitchTo().Frame(Driver.FindElement(locator));
        }

        public void Switch(By locator)
        {
            string webDriver = Driver.CurrentWindowHandle;
            foreach (string NewWebDriver in Driver.WindowHandles)
            {
                if (webDriver != NewWebDriver)
                {
                    Driver.SwitchTo().Window(NewWebDriver);
                }
            }

        }

        public void CtrlEnter(By locator)
        {
            Driver.FindElement(locator).SendKeys(Keys.Control + Keys.Enter);
        }

        public void Clear(By locator)
        {
            Driver.FindElement(locator).Clear();
        }

        public bool IsTextEmpty(By locator)
        {
            string text = Driver.FindElement(locator).Text;
            return text.IsNullOrEmpty();
        }

        public bool IsSelected(By locator)
        {
            return Driver.FindElement(locator).Selected;

        }

        public void Sleep(int time)
        {
            Thread.Sleep(time);
        }

        
        public void EncontrarElemento(By locator)
        {
            var element1 = Driver.FindElement(locator);
            Actions actions1 = new Actions(Driver);
            actions1.MoveToElement(element1);
            actions1.Perform();
        }

       

        public bool AreMessageEquals(By locator, string expectedMessage)
        {
            string Message = this.GetText(locator);
            return (expectedMessage.Equals(Message));
        }

        [Obsolete]
        public void afterStepLocal(QsTester testerPage)
        {
            if (testerPage != null && ScenarioContext.Current.TestError != null)
            {
                testerPage.SaveScreenShot(QSTestConstantes.URL_REPORT_SS + ScenarioContext.Current.ScenarioInfo.Title.Trim() + ".jpg");
                testerPage.Close();
            }

        }
    }
}
