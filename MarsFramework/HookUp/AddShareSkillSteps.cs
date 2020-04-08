using MarsFramework.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsFramework.HookUp
{
    [Binding]
    public class AddShareSkillSteps : Global.Base
    {
        [Given(@"I have clicked on the share skill button in my profile page")]
        public void GivenIHaveClickedOnTheShareSkillButtonInMyProfilePage()
        {
            Inititalize();
            Thread.Sleep(1500);

            ShareSkill shareskill = new ShareSkill();
            shareskill.ClickOnShareSkillBtn();

        }
        
        [Given(@"I have entered the skill")]
        public void GivenIHaveEnteredTheSkill()
        {
            ShareSkill shareskill = new ShareSkill();
            shareskill.EnterShareSkill();
        }
        
        [When(@"I press save button")]
        public void WhenIPressSaveButton()
        {
            ShareSkill shareskill = new ShareSkill();
            shareskill.ClickShareskillSaveBtn();
        }
        
        [Then(@"skill should be displayed on the listing")]
        public void ThenSkillShouldBeDisplayedOnTheListing()
        {
            ManageListings manageListings = new ManageListings();
            manageListings.ClickOnManageListing();
            manageListings.VerifySkill();
        }
    }
}
