Feature:User Login

A short summary of the feature

@tag1
Scenario: Successful Login with valid credentials
	Given  the user is on the login page
	When they enter a valid username and password
	Then they should be redirected to the dashboard
