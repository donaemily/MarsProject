using MarsFramework.Pages;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MarsFramework.HookUp
{
    [Binding]
    public class EditShareSkillSteps : Global.Base
    {

        [Given(@"I clicked on the manage listing tab on the profile page")]
        public void GivenIClickedOnTheManageListingTabOnTheProfilePage()
        {
            Inititalize();
            Thread.Sleep(1500);

            ManageListings manageListings = new ManageListings();
            manageListings.ClickOnManageListing();
        }        
        
      
        [Then(@"I clicked on the edit button corresponding to the skill and edited the skill")]
        public void ThenIClickedOnTheEditButtonCorrespondingToTheSkillAndEditedTheSkill()
        {
            ManageListings manageListings = new ManageListings();

            manageListings.EditListing();
        }

        [When(@"I pressed save button")]
        public void WhenIPressedSaveButton()
        {
            ManageListings manageListings = new ManageListings();

            manageListings.EditSaveBtn();
        }

    }
}
