using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab9.Selenium;

[TestClass]
public class LoginTest
{
    private IWebDriver _driver;

    private IConfigurationRoot _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    [TestInitialize]
    public void Initialize()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://www.goldtoe.com/login.php";
    }

    [TestMethod]
    public void Login()
    {
        //login
        var emailInput = _driver.FindElement(By.Id("login_email"));
        emailInput.SendKeys(_config["email"]);
        var passwordInput = _driver.FindElement(By.Id("login_pass"));
        passwordInput.SendKeys(_config["password"]);
        passwordInput.Submit();

        //check if we are logged in
        var expectedUrl = "https://www.goldtoe.com/account.php?action=order_status";
        Assert.AreEqual(expectedUrl, _driver.Url);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _driver.Quit();
    }
}