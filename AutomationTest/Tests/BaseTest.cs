using OpenQA.Selenium;
using AutomationTest.Drivers;
using Reqnroll.BoDi;

namespace AutomationTest.Tests
{
    public abstract class BaseTest : IDisposable
{
    protected IWebDriver Driver { get; }
    protected IObjectContainer Container { get; }
    private bool disposed = false;

    public BaseTest()
    {
        Driver = DriverFactory.GetDriver();
        Container = new ObjectContainer();
        Container.RegisterInstanceAs(Driver, typeof(IWebDriver));
        Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                Driver?.Dispose();
                Driver?.Quit();
            }
            disposed = true;
        }
    }
}
}