﻿using System.Net.Mail;
using AutoFixture;
using OpenQA.Selenium;
using Xunit.Abstractions;

namespace xUnitDemo;

public class SeleniumWithAutoFixtureData : IClassFixture<WebDriverFixture>
{
    private readonly WebDriverFixture _webDriverFixture;
    private readonly ITestOutputHelper _testOutputHelper;

    public SeleniumWithAutoFixtureData(WebDriverFixture webDriverFixture, ITestOutputHelper testOutputHelper)
    {
        _webDriverFixture = webDriverFixture;
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void TestRegisterUser()
    {
        var driver = _webDriverFixture.ChromeDriver;
        driver.Navigate().GoToUrl("http://eaapp.somee.com");
        
        var userName=new Fixture().Create<string>();
        var password = new Fixture().Create<string>();
        var email = new Fixture().Create<string>();
        
        
        driver.FindElement(By.Id("registerLink")).Click();
        driver.FindElement(By.Id("UserName")).SendKeys(userName);
        driver.FindElement(By.Id("Password")).SendKeys(password);
        driver.FindElement(By.Id("ConfirmPassword")).SendKeys(password);
        driver.FindElement(By.Id("Email")).SendKeys(email);
        _testOutputHelper.WriteLine("Test Done");
    }
}