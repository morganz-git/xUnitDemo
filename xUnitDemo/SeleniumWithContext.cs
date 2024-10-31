using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace xUnitDemo;
// 一种构造函数的写法
public class SeleniumWithContext(ITestOutputHelper testOutputHelper, WebDriverFixture webDriverFixture)
    : IClassFixture<WebDriverFixture>
{
    private readonly WebDriverFixture _webDriverFixture = webDriverFixture;
    private readonly ChromeDriver _chromeDriver = webDriverFixture.ChromeDriver;

    [Fact]
    public void ClassFixtureNavigate()
    {
        //Console.WriteLine("First test"); 不会有任何输出
        testOutputHelper.WriteLine("First Test");
        _chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
    }

    [Fact]
    public void ClassFixtureTestFillData()
    {
        var driver = _webDriverFixture.ChromeDriver;
        driver.Navigate().GoToUrl("http://eaapp.somee.com");
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys("admin");
        driver.FindElement(By.Id("Password")).SendKeys("password");
        driver.FindElement(By.Id("loginIn")).Click();

    }

}