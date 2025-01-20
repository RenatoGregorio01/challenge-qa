using OpenQA.Selenium;


namespace AutomationTest.Utilities
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot(IWebDriver driver, string fileNamePrefix)
        {
            if (driver is ITakesScreenshot takesScreenshot)
            {
                var screenshot = takesScreenshot.GetScreenshot();

                string timestamp = DateTime.Now.ToString("yyyyMMdd_HHmmss");

                string fileName = $"{fileNamePrefix}_{timestamp}.png";
                string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
                string screenshotsDir = Path.Combine(projectRoot, "../../../Screenshots");

                if (!Directory.Exists(screenshotsDir))
                {
                    Directory.CreateDirectory(screenshotsDir);
                }

                string filePath = Path.Combine(screenshotsDir, fileName);
                screenshot.SaveAsFile(filePath);

            }
            else
            {
                throw new InvalidOperationException("Driver não suporta captura de tela.");
            }
        }
    }
}
