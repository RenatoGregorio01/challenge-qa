using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;



namespace AutomationTest.Utilities
{
    public static class WaitUtils
    {

        public static bool WaitForElementToBeVisible(IWebDriver driver, IWebElement element, int timeoutInSeconds = 10)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(d => element.Displayed);
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }

    }
}
