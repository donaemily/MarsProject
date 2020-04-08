using MarsFramework.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using RelevantCodes.ExtentReports;
using static MarsFramework.Global.GlobalDefinitions;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.Pages
{
    internal class ManageListings
    {
        public ManageListings()
        {
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on Manage Listings Link
        [FindsBy(How = How.LinkText, Using = "Manage Listings")]
        private IWebElement manageListingsLink { get; set; }

        //View the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='eye icon'])[1]")]
        private IWebElement view { get; set; }

        //Delete the listing
        [FindsBy(How = How.XPath, Using = "//table[1]/tbody[1]")]
        private IWebElement delete { get; set; }

        //Edit the listing
        [FindsBy(How = How.XPath, Using = "(//i[@class='outline write icon'])[1]")]
        private IWebElement edit { get; set; }

        //Click on Yes or No
        [FindsBy(How = How.XPath, Using = "//div[@class='actions']")]
        private IWebElement clickActionsButton { get; set; }


        internal void ClickOnManageListing()
        {
            Thread.Sleep(1500);
            manageListingsLink.Click();

        }

        internal void EditListing()
        {
            //wait
            Thread.Sleep(1500);

            //Populating Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\Test Analyst\MyOnboarding\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");

            for (int i = 1; i <= 10; i++)
            {
                var title = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/table/tbody/tr[" + i + "]/td[3]"));
                var description = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/table/tbody/tr[" + i + "]/td[4]"));

                if (title.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && description.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
                {
                    edit.Click();
                    UpdateSkill();
                }
                return;
            }
        }

        internal void UpdateSkill()
        {
            //wait
            Thread.Sleep(1500);

            ShareSkill shareSkill = new ShareSkill();

            //Populating Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\Test Analyst\backup onboarding\marsframework-master\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");



            //Enter title
            shareSkill.Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Title"));

            //Enter Description
            shareSkill.Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Description"));

            //Select Category
            shareSkill.CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Category"));

            //Select Subcategory
            shareSkill.SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "SubCategory"));

            //Enter Tag
            shareSkill.Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Tags"));
            shareSkill.Tags.SendKeys(Keys.Enter);

            //Select service type
            string Service = GlobalDefinitions.ExcelLib.ReadData(2, "ServiceType");
            if (Service == "One-off service")
            {
                shareSkill.ServiceTypeOptions.FindElement(By.XPath("/ html / body / div / div / div[1] / div[2] / div / form / div[5] / div[2] / div[1] / div[2] / div / input")).Click();
            }

            else
            {
                shareSkill.ServiceTypeOptions.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
            }

            //Select Location
            string Location = GlobalDefinitions.ExcelLib.ReadData(2, "LocationType");
            if (Location == "On-site")
            {
                shareSkill.LocationTypeOption.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
            }
            else
            {
                shareSkill.LocationTypeOption.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
            }

            //Select skill trade option
            string skilltrade = GlobalDefinitions.ExcelLib.ReadData(2, "SkillTrade");
            if (skilltrade == "Skill-Exchange")
            {
                shareSkill.SkillTradeOption.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/label")).Click();
                shareSkill.SkillExchange.FindElement(By.XPath("(//input[contains(@name,'skillTrades')])[2]")).Click();
            }

            else
            {
                shareSkill.SkillTradeOption.FindElement(By.XPath("(//input[contains(@name,'skillTrades')])[2]"));
                shareSkill.CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(2, "Credit"));
            }

            //Select Active option
            string active = GlobalDefinitions.ExcelLib.ReadData(2, "Active");
            if (active == "Active")
            {
                shareSkill.ActiveOption.FindElement(By.XPath("(//input[contains(@name,'isActive')])[1]")).Click();

            }
            else
            {
                shareSkill.ActiveOption.FindElement(By.XPath("(//input[contains(@name,'isActive')])[2]")).Click();
            }
        }

        internal void EditSaveBtn()
        {
            ShareSkill shareSkill = new ShareSkill();
            shareSkill.Save.Click();

        }

        internal void DeleteListing()
        {
            //wait
            Thread.Sleep(1500);

            //Populating Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\Test Analyst\backup onboarding\marsframework-master\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");

            for (int i = 1; i <= 10; i++)
            {
                var title = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/table/tbody/tr[" + i + "]/td[3]"));
                var description = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/table/tbody/tr[" + i + "]/td[4]"));

                if (title.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && description.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
                {
                    GlobalDefinitions.driver.FindElement(By.XPath("(//i[contains(@class,'remove icon')])[" + 1 + "]")).Click();

                    GlobalDefinitions.driver.FindElement(By.XPath("//button[@class='ui icon positive right labeled button'][contains(.,'Yes')]")).Click();
                }
                return;
            }
        }

        internal void VerifySkill()
        {
            Global.Base bases = new Global.Base();
            Global.Base.ExtentReports();
            Thread.Sleep(1500);
            Global.Base.test = Global.Base.extent.StartTest("ShareSkill Added");

            driver.FindElement(By.XPath("(//i[contains(@class,'outline write icon')])[1]")).Click();


        }

    }


}
