using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace Variant5part1.PageObjects
{
    class BasePage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"Languages\"]/a[30]")]
        private IWebElement rusLanBtn { get; set; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            this.wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
            PageFactory.InitElements(driver, this);
        }

        private void waitUntilElementExists(string xpath)
        {
            this.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath(xpath)));
        }
    }
}
