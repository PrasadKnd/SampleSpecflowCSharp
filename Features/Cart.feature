Feature: Cart

Background: 
Given I navigate to 'https://cms.demo.katalon.com/' page

@mytag
Scenario: Verify Cart functionaility for removing items
	Given I add '4' random items to my cart
	When I view my cart
	Then I find total '4' item listed in my cart
	When I search for lowest price item and remove from my cart
	Then I am able to verify '3' items in my cart