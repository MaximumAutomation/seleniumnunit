using NPOI.SS.Formula.Functions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Chrome;
using SeleniumNUnit.Hook;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SeleniumNUnit
{
    class TestClass
    {
        
        [Test]
        public void MobileGesture()
        {
            AppiumOptions option = new AppiumOptions();
            option.AddAdditionalCapability("deviceName", Hooks.config.DeviceName);
            option.AddAdditionalCapability("platformName", Hooks.config.PlatformName);
            option.AddAdditionalCapability("platformVersion", Hooks.config.PlatformVersion);
            option.AddAdditionalCapability("app", Directory.GetCurrentDirectory()
                +Path.DirectorySeparatorChar+"ApiDemos-debug.apk");

            IWebDriver webDriver = new AndroidDriver<IWebElement>(new Uri(Hooks.config.AppiumUrl), option);
            webDriver.FindElement(By.XPath("//android.widget.TextView[@text='Views']")).Click();
            
            //swipescreen("Left", webDriver);
            //Thread.Sleep(2000);
            //swipescreen("Right", webDriver);

            while (webDriver.FindElements(By.XPath("//android.widget.TextView[@text='Tabs']")).Count == 0)
            {                
                swipescreen("Up", webDriver);
            }
            webDriver.FindElement(By.XPath("//android.widget.TextView[@text='Tabs']")).Click();
            
        }









        public void swipescreen(string direction,IWebDriver driver)
        {
            Size screensize = driver.Manage().Window.Size;
            double startwidth, startheight, endwidth=0, endheight=0;
            startwidth = screensize.Width / 2;
            startheight = screensize.Height / 5;
            int border = 10;

            switch (direction.ToUpper())
            {
                case "DOWN":
                    endwidth = screensize.Width / 2;
                    endheight = screensize.Height - border;
                    break;
                case "UP":
                    endwidth = screensize.Width / 2;
                    endheight = border;
                    break;
                case "LEFT":
                    endwidth = border;
                    endheight = screensize.Height / 5;
                    break;
                case "RIGHT":
                    endwidth = screensize.Width - border;
                    endheight = screensize.Height / 5;
                    break;
                default:
                    throw new Exception("Invalid direction for swipe operation");
                    
            }

            try
            {
                new TouchAction((IPerformsTouchActions)driver)                    
                    .Press(startwidth, startheight)
                    .Wait(1000)
                    .MoveTo(endwidth, endheight)
                    .Release().Perform();
            }
            catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }
    }
}
