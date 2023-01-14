using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lab9.Selenium;

[TestClass]
public class WishListTests
{
    private IWebDriver _driver;

    private IConfigurationRoot _config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

    [TestInitialize]
    public void Initialize()
    {
        _driver = new ChromeDriver();
        _driver.Url = "https://www.goldtoe.com/wishlist.php";

        //login
        var emailInput = _driver.FindElement(By.Id("login_email"));
        emailInput.SendKeys(_config["email"]);
        var passwordInput = _driver.FindElement(By.Id("login_pass"));
        passwordInput.SendKeys(_config["password"]);
        passwordInput.Submit();
    }

    [TestMethod]
    public void CreateWishList()
    {
        const string wishListName = "wishlist test";

        //wishlist create
        var button = _driver.FindElement(By.PartialLinkText("NEW"));
        button.Click();

        //enter wishlist name
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        var wishListNameInput = _driver.FindElement(By.Id("wishlistname"));
        wishListNameInput.SendKeys(wishListName);
        wishListNameInput.Submit();

        //check if new wishlist created
        var element = _driver.FindElement(By.LinkText(wishListName));
        Assert.IsNotNull(element);
    }

    [TestCleanup]
    public void Cleanup()
    {
        _driver.Quit();
    }
}