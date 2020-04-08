Feature: ShareSkill
	In order to add and share the skills
	As a profile admin
	I want to add edit and view my sills

@mytag
Scenario: Add a new skill to my list
	Given I have clicked on the share skill button in my profile page
	And I have entered the skill
	When I press save button
	Then skill should be displayed on the listing

Scenario: Edit an existing skill in my list
	Given I clicked on the manage listing tab on the profile page
	Then I clicked on the edit button corresponding to the skill and edited the skill
	When I pressed save button
	Then skill should be displayed on the listing

Scenario: Delete an existing skill in my list
	Given I clicked on the manage listing tab on the profile page
	Then I clicked on the delete button corresponding to the skill
	Then skill should not be displayed on the listing


