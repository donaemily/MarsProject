using MarsFramework.Pages;
using System;
using TechTalk.SpecFlow;

namespace MarsFramework.HookUp
{
    [Binding]
    public class DeleteShareSkillSteps
    {
        [Then(@"I clicked on the delete button corresponding to the skill")]
        public void ThenIClickedOnTheDeleteButtonCorrespondingToTheSkill()
        {
            ManageListings manageListings = new ManageListings();
            manageListings.DeleteListing();
        }
        
        [Then(@"skill should not be displayed on the listing")]
        public void ThenSkillShouldNotBeDisplayedOnTheListing()
        {
            ManageListings manageListings = new ManageListings();
            manageListings.ClickOnManageListing();
            manageListings.VerifySkill();
        }
    }
}
