using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Abstractions;

namespace xUnitDemo;

public class SeleniumWithoutContext
{
    private readonly ITestOutputHelper _testOutputHelper;

    private readonly ChromeDriver _chromeDriver;

    // ITestOutputHelper 是 xUnit 提供的一个接口，用于在测试执行期间记录输出信息。通过将 testOutputHelper 注入到构造函数中，
    // 可以在测试中使用它来输出日志或调试信息，帮助你更好地了解测试的执行情况。
    public SeleniumWithoutContext(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        var driver = new DriverManager().SetUpDriver(new ChromeConfig());
        _chromeDriver = new ChromeDriver();
    }

    [Fact]
    public void Test1()
    {
        //Console.WriteLine("First test"); 不会有任何输出
        // _testOutputHelper.WriteLine("First Test");
        _chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
    }
}