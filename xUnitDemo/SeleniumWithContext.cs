using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit.Abstractions;

namespace xUnitDemo;

// 一种构造函数的写法
public class SeleniumWithContext(ITestOutputHelper testOutputHelper, WebDriverFixture webDriverFixture)
    : IClassFixture<WebDriverFixture>
{
    private readonly WebDriverFixture _webDriverFixture = webDriverFixture;
    private readonly ChromeDriver _chromeDriver = webDriverFixture.ChromeDriver;

    // [Fact]
    // public void ClassFixtureNavigate()
    // {
    //     //Console.WriteLine("First test"); 不会有任何输出
    //     testOutputHelper.WriteLine("First Test");
    //     _chromeDriver.Navigate().GoToUrl("http://eaapp.somee.com");
    // }
    //
    // [Theory]
    // [InlineData("admin", "password")]
    // [InlineData("admin", "password1")]
    // [InlineData("admin", "password2")]
    // [InlineData("admin", "password3")]
    // public void TestLoginwWithFillData(string userName, string password)
    // {
    //     var driver = _webDriverFixture.ChromeDriver;
    //     driver.Navigate().GoToUrl("http://eaapp.somee.com");
    //     driver.FindElement(By.LinkText("Login")).Click();
    //     driver.FindElement(By.Id("UserName")).SendKeys(userName);
    //     driver.FindElement(By.Id("Password")).SendKeys(password);
    //     driver.FindElement(By.Id("loginIn")).Click();
    // }

    /*
     * 1. [Theory] 与 [MemberData(nameof(Data))]
     * [Theory]：xUnit 提供的用于参数化测试的注解，它允许一个测试方法接受不同的数据集，从而多次执行相同的测试逻辑。
     * [MemberData(nameof(Data))]：通过 MemberData 特性来指定测试数据源。在这里，nameof(Data) 表示将调用 Data
     * 属性中的数据。Data 必须是一个静态属性，返回一个 IEnumerable<object[]> 的集合。每一组数据会被传递给 TestRegisterUser 方法的参数。
     */
    [Theory]
    [MemberData(nameof(Data))]
    public void TestRegisterUser(string userName, string password, string cpassword, string email)
    {
        var driver = _webDriverFixture.ChromeDriver;
        driver.Navigate().GoToUrl("http://eaapp.somee.com");
        driver.FindElement(By.Id("registerLink")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys(userName);
        driver.FindElement(By.Id("Password")).SendKeys(password);
        driver.FindElement(By.Id("ConfirmPassword")).SendKeys(cpassword);
        driver.FindElement(By.Id("Email")).SendKeys(email);
        testOutputHelper.WriteLine("Test Done");
    }

    //MemberData 要求这里必须是object array, 并且必须是静态的
    // 属性的本质其实就是方法
    // => =>：这是 C# 的表达式主体语法，用于简化属性的 get 访问器，表示 Data 属性直接返回 List<object[]> 的实例。
    public static IEnumerable<object[]> Data => new List<object[]>
    {
        // 可以将 List<object[]> 替换为 object[][]（即数组的数组）， 但是换成array 以后，
        // 数组的大小是固定的，不能进行动态扩展
        new object[]
        {
            "morgan",
            "password",
            "password",
            "m@m.m"
        },
        new object[]
        {
            "morgan1",
            "password1",
            "password1",
            "m@m.m2"
        }
    };

    [Theory]
    [ClassData(typeof(DataClass))]
    public void TestRegisterUser01(string userName, string password, string cpassword, string email)
    {
        var driver = _webDriverFixture.ChromeDriver;
        driver.Navigate().GoToUrl("http://eaapp.somee.com");
        driver.FindElement(By.Id("registerLink")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys(userName);
        driver.FindElement(By.Id("Password")).SendKeys(password);
        driver.FindElement(By.Id("ConfirmPassword")).SendKeys(cpassword);
        driver.FindElement(By.Id("Email")).SendKeys(email);
        testOutputHelper.WriteLine("Test Done");
    }

    class DataClass : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { "morgan", "password", "password", "m@m.m" };
            yield return new object[] { "morgan1", "password1", "password1", "m@m.m2" };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}