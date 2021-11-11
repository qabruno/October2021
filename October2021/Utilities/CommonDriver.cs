using NUnit.Framework;
using October2021.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace October2021.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void LoginActions()
        {
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);

        }

        [OneTimeTearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
