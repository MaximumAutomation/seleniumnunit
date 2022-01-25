using AventStack.ExtentReports.Model;
using Microsoft.VisualStudio.TestPlatform.Common.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using SeleniumNUnit.Hook;
using SeleniumNUnit.Libraries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace SeleniumNUnitProject.StepDefinition
{
    [Binding]
    class StepDefinition 
    {        
        [ThreadStatic]
        public static IWebDriver webDriver;
        string filepath = System.IO.Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + @"Data\";

        [Given(@"User navigates to url ""(.*)""")]
        public void GivenUserNavigatesToUrl(string p0)
        {
            if (Hooks.config.BrowserType.ToLower() == "chrome")
            {
                new DriverManager().SetUpDriver(new ChromeConfig());
                webDriver = new ChromeDriver();
            }
            else if (Hooks.config.BrowserType.ToLower() == "ie")
            {
                new DriverManager().SetUpDriver(new InternetExplorerConfig());
                webDriver = new InternetExplorerDriver();
            }
            else if (Hooks.config.BrowserType.ToLower() == "firefox")
            {
                new DriverManager().SetUpDriver(new FirefoxConfig());
                webDriver = new FirefoxDriver();
            }
            //webDriver.Navigate().GoToUrl(p0);
            //Serilog.Log.Debug("Navigated to {0} on {1} browser", p0, Hooks.config.BrowserType);
            webDriver.Manage().Window.Maximize();
        }

        [When(@"User input text ""(.*)"" on ""(.*)""")]
        public void GivenUserInputTextOn(string p0, string p1)
        {
            //IWebElement webelement = webDriver.FindElement(By.XPath(p1));
            //webelement.SendKeys(p0);
            //Serilog.Log.Debug("Entered text {0} in {1}", p0, p1);
        }

        [When(@"User clicks on ""(.*)""")]
        public void WhenUserClicksOn(string p0)
        {
            //IWebElement webelement = webDriver.FindElement(By.XPath(p0));
           // webelement.Click();
           // Serilog.Log.Debug("Clicked on object {0}", p0);
        }

        [Then(@"User verify value of ""(.*)"" is ""(.*)""")]
        public void ThenUserVerfyValueOfIs(string identifier, string expectedval)
        {
            //IWebElement webelement = webDriver.FindElement(By.XPath(identifier));
            //Assert.AreEqual(expectedval, webelement.Text);
        }

        [Then(@"User closes the browser")]
        public void ThenUserClosesTheBrowser()
        {
            webDriver.Quit();
        }

        [When(@"User create excel file ""(.*)"" using data")]
        public void WhenUserCreateExcelFileUsingData(string filename, Table table)
        {

            ExcelOperations excelOperations = new ExcelOperations();
            excelOperations.CreateXlsFile(System.IO.Directory.GetParent(@"../../../").FullName
                + Path.DirectorySeparatorChar + @"Data\" + filename, table);
            
        }

        [When(@"User reads file ""(.*)""")]
        public void WhenUserReadsFile(string filename)
        {
            ExcelOperations excelOperations = new ExcelOperations();
            excelOperations.ReadXlsFile(filepath + filename);
        }

    }
}
