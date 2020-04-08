using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using MarsFramework.Global;
using RelevantCodes.ExtentReports;
using static MarsFramework.Global.GlobalDefinitions;
using static NUnit.Core.NUnitFramework;

namespace MarsFramework.Pages
{
    internal class ShareSkill
    {
        public ShareSkill()
        {
            Thread.Sleep(1500);
            PageFactory.InitElements(Global.GlobalDefinitions.driver, this);
        }

        //Click on ShareSkill Button

        [FindsBy(How = How.LinkText, Using = "Share Skill")]
        public IWebElement ShareSkillButton { get; set; }

        //Enter the Title in textbox
        [FindsBy(How = How.Name, Using = "title")]
        public IWebElement Title { get; set; }

        //Enter the Description in textbox
        [FindsBy(How = How.Name, Using = "description")]
        public IWebElement Description { get; set; }

        //Click on Category Dropdown
        [FindsBy(How = How.Name, Using = "categoryId")]
        public IWebElement CategoryDropDown { get; set; }

        //Click on SubCategory Dropdown
        [FindsBy(How = How.Name, Using = "subcategoryId")]
        public IWebElement SubCategoryDropDown { get; set; }

        //Enter Tag names in textbox
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[contains(@class,'ui container')]/div[contains(@class,'listing')]/form[contains(@class,'ui form')]/div[contains(@class,'tooltip-target ui grid')]/div[contains(@class,'twelve wide column')]/div[contains(@class,'')]/div[contains(@class,'ReactTags__tags')]/div[contains(@class,'ReactTags__selected')]/div[contains(@class,'ReactTags__tagInput')]/input[1]")]
        public IWebElement Tags { get; set; }

        //Select the Service type
        [FindsBy(How = How.XPath, Using = "//form/div[5]/div[@class='twelve wide column']/div/div[@class='field']")]
        public IWebElement ServiceTypeOptions { get; set; }

        //Select the Location Type
        [FindsBy(How = How.XPath, Using = "//form/div[6]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        public IWebElement LocationTypeOption { get; set; }

        //Click on Start Date dropdown
        [FindsBy(How = How.Name, Using = "startDate")]
        public IWebElement StartDateDropDown { get; set; }

        //Click on End Date dropdown
        [FindsBy(How = How.Name, Using = "endDate")]
        public IWebElement EndDateDropDown { get; set; }

        //Storing the table of available days
        [FindsBy(How = How.XPath, Using = "//body/div/div/div[@id='service-listing-section']/div[@class='ui container']/div[@class='listing']/form[@class='ui form']/div[7]/div[2]/div[1]")]
        public IWebElement Days { get; set; }

        //Storing the starttime
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        public IWebElement StartTime { get; set; }

        //Click on StartTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[2]/input[1]")]
        public IWebElement StartTimeDropDown { get; set; }

        //Click on EndTime dropdown
        [FindsBy(How = How.XPath, Using = "//div[3]/div[3]/input[1]")]
        public IWebElement EndTimeDropDown { get; set; }

        //Click on Skill Trade option
        [FindsBy(How = How.XPath, Using = "//form/div[8]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        public IWebElement SkillTradeOption { get; set; }

        //Enter Skill Exchange
        [FindsBy(How = How.XPath, Using = "//div[@class='form-wrapper']//input[@placeholder='Add new tag']")]
        public IWebElement SkillExchange { get; set; }

        //Enter the amount for Credit
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Amount']")]
        public IWebElement CreditAmount { get; set; }

        //Click on Active/Hidden option
        [FindsBy(How = How.XPath, Using = "//form/div[10]/div[@class='twelve wide column']/div/div[@class = 'field']")]
        public IWebElement ActiveOption { get; set; }

        //Click on Save button
        [FindsBy(How = How.XPath, Using = "//input[@value='Save']")]
        public IWebElement Save { get; set; }


        public void ClickOnShareSkillBtn()
        {
            Thread.Sleep(1500);

            //Click ShareSkill Button
            ShareSkillButton.Click();
        }
        internal void EnterShareSkill()
        {
            //wait
            Thread.Sleep(1500);

            //Initiate no of rows in Excel file
            int row = GlobalDefinitions.ExcelLib.NumberofRows(@"D:\Test Analyst\MyOnboarding\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");

            //Populating Excel file
            GlobalDefinitions.ExcelLib.PopulateInCollection(@"D:\Test Analyst\MyOnboarding\marsframework-master\MarsFramework\ExcelData\TestDataShareSkill.xlsx", "ShareSkill");



            for (var i = 2; i <= row + 1; i++)
            {
                //Enter title
                Title.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Title"));

                //Enter Description
                Description.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Description"));

                //Select Category
                CategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Category"));

                //Select Subcategory
                SubCategoryDropDown.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "SubCategory"));

                //Enter Tag
                Tags.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Tags"));
                Tags.SendKeys(Keys.Enter);

                //Select service type
                string Service = GlobalDefinitions.ExcelLib.ReadData(i, "ServiceType");
                if (Service == "One-off service")
                {
                    ServiceTypeOptions.FindElement(By.XPath("/ html / body / div / div / div[1] / div[2] / div / form / div[5] / div[2] / div[1] / div[2] / div / input")).Click();
                }

                else
                {
                    ServiceTypeOptions.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/input")).Click();
                }

                //Select Location
                string Location = GlobalDefinitions.ExcelLib.ReadData(i, "LocationType");
                if (Location == "On-site")
                {
                    LocationTypeOption.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[6]/div[2]/div/div[1]/div/input")).Click();
                }
                else
                {
                    LocationTypeOption.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input")).Click();
                }

                //Select skill trade option
                string skilltrade = GlobalDefinitions.ExcelLib.ReadData(i, "SkillTrade");
                if (skilltrade == "Skill-Exchange")
                {
                    SkillTradeOption.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/label")).Click();
                    SkillExchange.FindElement(By.XPath("(//input[contains(@name,'skillTrades')])[2]")).Click();
                }

                else
                {
                    SkillTradeOption.FindElement(By.XPath("(//input[contains(@name,'skillTrades')])[2]"));
                    CreditAmount.SendKeys(GlobalDefinitions.ExcelLib.ReadData(i, "Credit"));
                }

                //Select Active option
                string active = GlobalDefinitions.ExcelLib.ReadData(i, "Active");
                if (active == "Active")
                {
                    ActiveOption.FindElement(By.XPath("(//input[contains(@name,'isActive')])[1]")).Click();

                }
                else
                {
                    ActiveOption.FindElement(By.XPath("(//input[contains(@name,'isActive')])[2]")).Click();
                }
            }

        }

        public void ClickShareskillSaveBtn()
        {
            Save.Click();
        }

        internal void ViewSkill()
        {
            Global.Base bases = new Global.Base();
            Global.Base.ExtentReports();
            Thread.Sleep(1500);
            Global.Base.test = Global.Base.extent.StartTest("ShareSkill Added");
            while (true)
            {
                for (int i = 1; i <= 10; i++)
                {
                    var title = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/table/tbody/tr[" + i + "]/td[3]"));
                    var description = GlobalDefinitions.driver.FindElement(By.XPath("/html/body/div/div/div/div/div/div/table/tbody/tr[" + i + "]/td[4]"));

                    if (title.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Title") && description.Text == GlobalDefinitions.ExcelLib.ReadData(2, "Description"))
                    {
                        Global.Base.test.Log(LogStatus.Pass, "Test Passed. ShareSkill Added");
                        SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "ShareSkill added sucessfully");
                        Assert.AreEqual(Title.Text, GlobalDefinitions.ExcelLib.ReadData(2, "Title"));
                    }
                    return;
                }
            }

        }
    }
}
