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
    class TM_Tests : CommonDriver
    {

        [Test]
        public void CreateTMTest()
        {
     
            // TM page object initialization and definition
            TMPage tmPageObj = new TMPage();
            tmPageObj.CreateTM(driver);
        }

        [Test]
        public void EditTMTest()
        {
            // Edit TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.EditTM(driver);
        }

        [Test]
       public void DeleteTMTest()
        {
            // Delete TM
            TMPage tmPageObj = new TMPage();
            tmPageObj.DeleteTM(driver);
        }


    }
}
