using OpenQA.Selenium;
using Xunit.Abstractions;

namespace xUnitDemo;

// IClassFixture<WebDriverFixture>：实现了 IClassFixture 接口，将 WebDriverFixture
// 作为类级别的共享实例。这意味着 WebDriverFixture 的实例在该类的所有测试方法中是共享的，
// 避免重复创建 WebDriver 实例。
[Collection("Sequence")] //用来实现顺序测试， 一个一个跑
public class SecondSeleniumTest : IClassFixture<WebDriverFixture>
{
    private readonly WebDriverFixture webDriverFixture;
    private readonly ITestOutputHelper testOutputHelper;

    public SecondSeleniumTest(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
    {
        this.webDriverFixture = webDriverFixture;
        this.testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void ClassFixtureNavigate()
    {
        testOutputHelper.WriteLine("First Test");
        webDriverFixture.ChromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
    }

    [Theory]
    [InlineData("admin", "password")]
    public void TestLoginWithFullData(string username, string password)
    {
        var driver = webDriverFixture.ChromeDriver;
        testOutputHelper.WriteLine("First Test");
        driver.Navigate().GoToUrl("http://eaapp.somee.com");
        driver.FindElement(By.LinkText("Login")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys(username);
        driver.FindElement(By.Id("Password")).SendKeys(password);
//        driver.FindElement(By.Id("loginIn")).Click();
//错误验证
        var exception = Assert.Throws<NoSuchElementException>(() => driver.FindElement(By.Id("LoginIn")).Click());
        Assert.Contains("no suck element", exception.Message);

        testOutputHelper.WriteLine("Test Done");
    }
}