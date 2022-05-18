Feature: Hudl Login Tests

Scenario: Hudl Login Invalid User Details Test

	Given I navigate to Hudl app page
	When I click on "LoginButton"
	And I enter invalid Email, Password and click Submit button
	Then I see a page with message "We didn't recognize that email and/or password." and index in "2"
	
Scenario: Hudl Login Valid User Details Test

	Given I navigate to Hudl app page
	When I click on "LoginButton"
	And I enter valid Email, Password and click Submit button
	Then I see a "Home" menu and index in "3"
	And I see a "Explore" menu and index in "2"
	When I click on "CoachText"
	And I click on "LogoutButton"
	Then I see a "We power sports" menu and index in "1"