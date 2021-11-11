using NUnit.Framework;
using October2021.Pages;
using October2021.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace October2021
{
    [TestFixture]
    [Parallelizable]
    class TM_Tests : CommonDriver
    {

        [Test, Order (1), Description("Check if user is able to create a Time record with valid data")]
        public void CreateTMTest()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);
        }

        [Test, Order(2), Description("Check if user is able to edit an existing Time record")]
        public void EditTMTest()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // Edit TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(driver);
        }

        [Test, Order(3), Description("Check if user is able to delete a Time record")]
       public void DeleteTMTest()
        {
            // Home page object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.GoToTMPage(driver);

            // Delete TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTM(driver);
        }


    }
}
