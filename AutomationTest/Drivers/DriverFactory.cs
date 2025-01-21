using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTest.Drivers
{
    public static class DriverFactory
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver(string browser = "chrome")
        {
            if (_driver == null)
            {
                Console.WriteLine($"Inicializando o navegador '{browser}' localmente...");

                if (browser.ToLower() != "chrome")
                {
                    throw new ArgumentException($"Apenas o navegador 'chrome' é suportado neste momento.");
                }

                try
                {
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddArgument("--start-maximized");

                    _driver = new ChromeDriver(chromeOptions);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao inicializar o navegador '{browser}': {ex.Message}");
                    throw new WebDriverException($"Falha ao inicializar o ChromeDriver.", ex);
                }
            }

            return _driver;
        }

        public static void QuitDriver()
        {
            if (_driver != null)
            {
                _driver.Quit();
                _driver = null;
            }
        }
    }
}