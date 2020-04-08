using NUnit.Framework;
using MarsFramework.Pages;
using System.Threading;
using TechTalk.SpecFlow;
using System;
using static MarsFramework.Global.GlobalDefinitions;
using MarsFramework.Global;
using RelevantCodes.ExtentReports;

namespace MarsFramework
{
    public class Program
    {
        
        class User : Global.Base
        {
            public void Setup()
            {
                Inititalize();
                Thread.Sleep(1500);

            }

            public void ShareSkill()
            {

                var shareskill = new Pages.ShareSkill();
                //PageFactory.InitElements(Driver, shareskill);
                shareskill.ClickOnShareSkillBtn();
                shareskill.EnterShareSkill();
                shareskill.ClickShareskillSaveBtn();


            }
           
            public void Viewshareskill()
            {
                var shareskill = new Pages.ShareSkill();
                ManageListings manageListings = new ManageListings();
                manageListings.ClickOnManageListing();
                manageListings.VerifySkill();
            }

            public void EditSkill()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.ClickOnManageListing();
                manageListings.EditListing();
                manageListings.EditSaveBtn();
            }

            public void DeleteSkill()
            {
                ManageListings manageListings = new ManageListings();
                manageListings.ClickOnManageListing();
                manageListings.DeleteListing();
            }

            

        }
    }
}