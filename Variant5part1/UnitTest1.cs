using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace Variant5part1
{
    [TestClass]
    public class LoremIpsum_Test1 {
        [TestMethod]
        public void FirstTextArea_RussianFishWord_Present() {
            // Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://lipsum.com/");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
           
            // Act
            IWebElement rusLanBtn = driver.FindElement(By.XPath("//*[@id=\"Languages\"]/a[30]"));
            rusLanBtn.Click();

            string firstParagraphXPath = "//*[@id=\"Panes\"]/div[1]/p";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(firstParagraphXPath)));
            IWebElement firstParagraph = driver.FindElement(By.XPath(firstParagraphXPath));
            string firstParagraphText = firstParagraph.Text;

            // Assert
            Assert.IsTrue(firstParagraphText.Contains("рыба"));
        }
    }
    [TestClass]
    public class LoremIpsum_Test2
    {
        [TestMethod]
        public void GeneratedText_LoremWordAverageOccurrencesNumber_BiggerThan3() {

            // Arrange
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://lipsum.com/");
            WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));

            // Act
            IWebElement genLorIp = driver.FindElement(By.XPath("//*[@id=\"generate\"]"));
            genLorIp.Click();
           
            double count = GetLoremWordOccurrencesNumber(driver, wait);
            for (int i = 0; i < 10; i++) {
                driver.Navigate().Refresh();
                count += GetLoremWordOccurrencesNumber(driver, wait);
            }
            
            // Assert
            Assert.IsTrue((count / 10.0) >= 3);
        }

        private int GetLoremWordOccurrencesNumber(IWebDriver driver, WebDriverWait wait)
        {
            string paragraphXPath = "//*[@id=\"lipsum\"]/p";
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(paragraphXPath)));
            IList<IWebElement> paragraphElements = driver.FindElements(By.XPath(paragraphXPath));
            int count = 0;
            foreach (IWebElement paragraphElement in paragraphElements) {
                string paragraphText = paragraphElement.Text;
                if (paragraphText.ToLower().Contains("lorem")) {
                    count++;
                }
            }
            return count;
        }
    }
}
