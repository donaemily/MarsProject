using MarsFramework.Config;
using MarsFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using RelevantCodes.ExtentReports;
using static MarsFramework.Global.GlobalDefinitions;
using System.IO;

namespace MarsFramework.Global
{
    public class Base
    {
        private void CreateFolder()
        {

            bool folderExists = Directory.Exists(@"C:\Program Files\MyApplication\NewFolder");

            if (!Directory.Exists(@"C:\Program Files\MyApplication\NewFolder"))
                 Directory.CreateDirectory(@"C:\Program Files\MyApplication\NewFolder");
        }


        #region To access Path from resource file

        private static string solutionParentDirectory = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
        public static String ExcelPath = Path.Combine(solutionParentDirectory, @MarsResource.ExcelPath);
        public static String ScreenshotPath = Path.Combine(solutionParentDirectory, @MarsResource.ScreenShotPath);

        public static int Browser = Int32.Parse(MarsResource.Browser);
        //public static String ExcelPath = MarsResource.ExcelPath;
        //public static string ScreenshotPath = MarsResource.ScreenShotPath;
        public static string ReportPath = MarsResource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        //private IWebDriver Driver;

        public static void ExtentReports()
        {
            extent = new ExtentReports(ReportPath, true, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);
        }

        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;
                case 2:
                    GlobalDefinitions.driver = new ChromeDriver();
                    GlobalDefinitions.driver.Manage().Window.Maximize();
                    break;

            }

            #region Initialise Reports

            extent = new ExtentReports(ReportPath, false, DisplayOrder.NewestFirst);
            extent.LoadConfig(MarsResource.ReportXMLPath);

            #endregion

            //add the website
            driver.Navigate().GoToUrl("http://192.168.99.100:5000");

            if (MarsResource.IsLogin == "true")
            {
                SignIn loginobj = new SignIn();
                loginobj.LoginSteps();
            }
            else
            {
                SignUp obj = new SignUp();
                obj.register();
            }

        }

        //public static string BaseUrl
        //{
        //    get { return GlobalDefinitions.Url; }
        //}

        //public static void NavigateUrl()
        //{
        //    driver.Navigate().GoToUrl(BaseUrl);
        //}

        [TearDown]
        public void TearDown()
        {
            // Screenshot
            test = extent.StartTest("Test recorded");
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(LogStatus.Info, "Image example: " + test.AddScreenCapture(img));
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            //extent.Flush();
            // Close the driver :)            
            GlobalDefinitions.driver.Close();
            GlobalDefinitions.driver.Quit();
        }


        #endregion



    }
}