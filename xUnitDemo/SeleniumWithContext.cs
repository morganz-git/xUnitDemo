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
    
}