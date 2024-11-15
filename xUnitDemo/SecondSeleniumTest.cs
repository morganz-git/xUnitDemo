using FluentAssertions;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace xUnitDemo;

// IClassFixture<WebDriverFixture>：实现了 IClassFixture 接口，将 WebDriverFixture
// 作为类级别的共享实例。这意味着 WebDriverFixture 的实例在该类的所有测试方法中是共享的，
// 避免重复创建 WebDriver 实例。
[Collection("Sequence")] //用来实现顺序测试， 一个一个跑
public class SecondSeleniumTest : IClassFixture<WebDriverFixture>
{
    private readonly WebDriverFixture _webDriverFixture;
    private readonly ITestOutputHelper _testOutputHelper;

    public SecondSeleniumTest(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
    {
        _webDriverFixture = webDriverFixture;
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ClassFixtureNavigate()
    {
        _testOutputHelper.WriteLine("First Test");
        _webDriverFixture.ChromeDriver
            .Navigate()
            .GoToUrl("http://eaapp.somee.com");
        var anchor = _webDriverFixture.ChromeDriver.FindElements(By.TagName("a"));
        anchor.Should().HaveCountGreaterThan(2);
    }

    [Theory]
    [InlineData("admin", "password")]
    public void TestLoginWithFullData(string username, string password)
    {
        var driver = _webDriverFixture.ChromeDriver;
        _testOutputHelper.WriteLine("First Test");
        driver.Navigate().GoToUrl("http://eaapp.somee.com");
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys(username);
        driver.FindElement(By.Id("Password")).SendKeys(password);
        //        driver.FindElement(By.Id("loginIn")).Click();
        //错误验证
        //        var exception = Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("LoginIn")).Click());
        var exception =
            Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("LoginIn - eror")).Click());
        //        Assert.Contains("no suck element", exception.Message);
        exception.Message.Should().Contain("no such element");

        _testOutputHelper.WriteLine("Test Done");
    }
}