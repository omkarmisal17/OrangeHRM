using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace OrangeHRM.Tests.PageObjectFiles;

public class LoginPage
{
    private const string LoginUrl =
        "https://opensource-demo.orangehrmlive.com/web/index.php/auth/login";

    private static readonly By UsernameInput = By.XPath("//input[@name='username']");
    private static readonly By PasswordInput = By.XPath("//input[@name='password']");
    private static readonly By LoginButton = By.XPath("//button[@type='submit']");

    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    public void Open()
    {
        _driver.Navigate().GoToUrl(LoginUrl);
        _wait.Until(driver => driver.FindElement(UsernameInput).Displayed);
    }

    public void Login(string username, string password)
    {
        _driver.FindElement(UsernameInput).SendKeys(username);
        _driver.FindElement(PasswordInput).SendKeys(password);
        _driver.FindElement(LoginButton).Click();
    }

    public bool IsDashboardDisplayed()
    {
    return _wait.Until(driver =>
        driver.FindElements(By.XPath("//h6[text()='Dashboard']")).Count > 0);
    }
}