using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace OrangeHRM.Tests.SupportCoreFiles;

public abstract class TestBase
{
    private IWebDriver? _driver;
    protected IWebDriver Driver => _driver ?? throw new InvalidOperationException("WebDriver is not initialized. Call InitializeDriver() before accessing the Driver.");

    [SetUp]
    public void InitializeDriver()
    {
        var options = new ChromeOptions();

        if (Environment.GetEnvironmentVariable("CI") == "true")
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }
        else
        {
            options.AddArgument("--start-maximized");
        }

        _driver = new ChromeDriver(options);
    }

    [TearDown]
    public void TearDown()
    {
        var driver = _driver;
        _driver = null;

        if (driver == null)
        {
            return;
        }
        try
        {
            driver.Quit();
        }

        finally
        {
            driver.Dispose();
        }
    }
}