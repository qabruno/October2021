using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace October2021.Pages
{
    class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // click on Create New button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

            // click on TypeCode dropdown and select Time
            IWebElement tmDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            tmDropdown.Click();

            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            // enter Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("October2021");

            // enter description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("October2021");

            // enter price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("12");

            // click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(2000);

            // click on go to last page button
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(2000);

            // check if time record is present in the table and has expected values
            IWebElement actualCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement actualTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            IWebElement actualDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement actualPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

            // 1 Option
            Assert.That(actualCode.Text == "October2021", "actual code an expected code do not match.");
            Assert.That(actualTypeCode.Text == "T", "actual Type Code and expected Type Code do not match.");
            Assert.That(actualDescription.Text == "October2021", "actual description and expected description do not match.");
            Assert.That(actualPrice.Text == "$12.00", "actual price and expected price do not match.");

        }

        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(2000);

            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "October2021")
            {
                // click on edit button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();

                // edit code textbox
                IWebElement codeTextBox = driver.FindElement(By.Id("Code"));
                codeTextBox.Clear();
                codeTextBox.SendKeys("EditedOctober2021");

                // edit description
                IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
                descriptionTextbox.Clear();
                descriptionTextbox.SendKeys("EditedOctober2021");

                // edit price
                IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                IWebElement priceTextbox = driver.FindElement(By.Id("Price"));

                priceInputTag.Click();
                priceTextbox.Clear();
                priceInputTag.Click();
                priceTextbox.SendKeys("170");

                // click on save button
                IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
                saveButton.Click();
                Thread.Sleep(2000);

                // click on go to last page button
                IWebElement goToLastPageButton1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageButton1.Click();
                Thread.Sleep(2000);

                // Assertion
                IWebElement CreatedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement CreatedTypeCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
                IWebElement CreatedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                IWebElement CreatedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

                // Assertion
                Assert.That(CreatedCode.Text == "EditedOctober2021", "Code record hasn't been deleted.");
                Assert.That(CreatedTypeCode.Text == "T", "TypeCode record hasn't been deleted.");
                Assert.That(CreatedDescription.Text == "EditedOctober2021", "Description record hasn't been deleted.");
                Assert.That(CreatedPrice.Text == "$170.00", "Price record hasn't been deleted.");
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited");
            }

        }

        public void DeleteTM(IWebDriver driver)
        {
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "EditedOctober2021")
            {
                // Click on the Delete Button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(2000);

                driver.SwitchTo().Alert().Accept();

                // Assert that Time record has been deleted.
                IWebElement goToLastPageBtn1 = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPageBtn1.Click();
                Thread.Sleep(2000);

                IWebElement editedCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
                IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));

                // Assertion
                Assert.That(editedCode.Text != "EditedOctober2021", "Code record hasn't been deleted.");
                Assert.That(editedDescription.Text != "EditedOctober2021", "Description record hasn't been deleted.");
                Assert.That(editedPrice.Text != "$170.00", "Price record hasn't been deleted.");
            }
            else
            {
                Assert.Fail("Record to be deleted hasn't been found. Record not deleted.");
            }

        }
    }


}
