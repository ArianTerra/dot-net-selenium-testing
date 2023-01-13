using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Microsoft.Extensions.Configuration;

//load config
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var email = config["email"];
var password = config["password"];

var driver = new ChromeDriver();
driver.Url = "https://www.goldtoe.com/wishlist.php";

//login
var emailInput = driver.FindElement(By.Id("login_email"));
emailInput.SendKeys(email);
var passwordInput = driver.FindElement(By.Id("login_pass"));
passwordInput.SendKeys(password);
passwordInput.Submit();

//wishlist create
var button = driver.FindElement(By.PartialLinkText("NEW"));
button.Click();

//generate random wishlist name with Bogus
var lorem = new Bogus.DataSets.Lorem();
var wishListName = lorem.Slug();

//enter wishlist name
driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
var wishListNameInput = driver.FindElement(By.Id("wishlistname"));
wishListNameInput.SendKeys(wishListName);
wishListNameInput.Submit();