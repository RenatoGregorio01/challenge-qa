using OpenQA.Selenium;
using AutomationTest.Drivers;


namespace AutomationTest.Utilities
{
    public static class TestIdUtils
    {
        public static IWebElement FindByTestId(string testId)
        {
            // Recupera o valor da variável de ambiente BROWSER, com valor padrão "chrome"
            var driver = DriverFactory.GetDriver("chrome"); // Passando o navegador para o DriverFactory
            return driver.FindElement(By.CssSelector($"[data-testid='{testId}']"));
        }
    }
}
