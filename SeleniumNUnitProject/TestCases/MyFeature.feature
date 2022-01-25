Feature: BookVerifications
	

Scenario: Verify selenium webdriver book price
	Given User navigates to url "http://amazon.com"	
	When User input text "selenium test" on "//input[@id='twotabsearchtextbox']"
	When User clicks on "//input[@type='submit']"	
	When User clicks on "//span[contains(text(),'Webdriver 3.0')]"
	Then User verify value of "//span[@class='a-color-base']/span" is "$49.99"
	Then User closes the browser



Scenario: Verify java book price
	Given User navigates to url "http://amazon.com"	
	When User input text "java book" on "//input[@id='twotabsearchtextbox']"
	When User clicks on "//input[@type='submit']"	
	When User clicks on "//span[contains(text(),'Java: A Beginner's Guide, Eighth Edition')]"
	Then User verify value of "//span[@class='a-color-base']/span" is "$11.67"
	Then User closes the browser



Scenario: Verify C# book price
	Given User navigates to url "http://amazon.com"	
	When User input text "selenium test" on "//input[@id='twotabsearchtextbox']"
	When User clicks on "//input[@type='submit']"	
	When User clicks on "//span[contains(text(),'Learn C# in One Day')]"
	Then User verify value of "//span[@class='a-color-base']/span" is "$25.52"
	Then User closes the browser

Scenario: as
 When User create excel file "myxl.xls" using data
 | first | second |
 | erer  | ererer |
 | erer  | ererer |

	
	