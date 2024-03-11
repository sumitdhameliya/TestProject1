using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;


namespace SeleniumTests
{
    [TestFixture]
    public class GoogleTranslateTest
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://translate.google.com/");
        }

        [Test]
        public void TranslateHelloToFrench()
        {
            // Wait and click the source language dropdown
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#yDmH0d > c-wiz > div > div.ToWKne > c-wiz > div.OlSOob > c-wiz > div.ccvoYb.EjH7wc > div.aCQag > c-wiz > div.zXU7Rb > c-wiz > div:nth-child(2) > button"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[1]/c-wiz/div[2]/c-wiz/div[1]/div/div[3]/div/div[3]/div[29]"))).Click();

            // Wait and click the target language dropdown
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("#yDmH0d > c-wiz > div > div.ToWKne > c-wiz > div.OlSOob > c-wiz > div.ccvoYb.EjH7wc > div.aCQag > c-wiz > div.zXU7Rb > c-wiz > div:nth-child(5) > button"))).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[1]/c-wiz/div[2]/c-wiz/div[2]/div/div[3]/div/div[2]/div[35]"))).Click();

            // Enter text in the source text area
            IWebElement inputArea = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[1]/span/span/div/textarea")));
            inputArea.Click();
            inputArea.SendKeys("Hello");

            // Wait for the translation to appear and validate
            IWebElement result = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"yDmH0d\"]/c-wiz/div/div[2]/c-wiz/div[2]/c-wiz/div[1]/div[2]/div[2]/c-wiz[2]/div/div[6]/div/div[1]/span[1]/span/span")));
            Assert.AreEqual("Bonjour", result.Text.Trim());

            // Close the browser window
            driver.Quit();
        }

        [TearDown]
        protected void TearDown()
        {
            driver.Quit();
        }
    }
}
