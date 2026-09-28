using NUnit.Framework;
using OrangeHRM.Tests.PageObjectFiles;
using OrangeHRM.Tests.SupportCoreFiles;

namespace OrangeHRM.Tests.TestClassFiles;

public class LoginTests : TestBase
{
    [Test]
    public void LoginWithValidCredentialsDisplaysDashboard(){
        //Arrange
        var loginPage = new LoginPage(Driver);

        //Act
        loginPage.Open();
        loginPage.Login("Admin", "admin123");

        //Assert
        Assert.That(loginPage.IsDashboardDisplayed(), Is.True);
    }
}