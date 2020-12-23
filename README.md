# Usage Instructions

## Run Search Program:

1. Download and install **Visual Studio Community 2019** via the link below

	https://visualstudio.microsoft.com/thank-you-downloading-visual-studio/?sku=Community&rel=16&embed-exp=true

2. Open the solution file with Visual Studio:

	> /ZendeskSearch/ZendeskSearch.sln

3. Build the solution within Visual Studio

	> Right click on the solution and choose "Build Solution".

4. Set the project **"ZendeskSearch"** as the startup project

	> Right click on the project **"ZendeskSearch"** and choose "Set as Startup Project".

5. Run program

	> Press "F5" key.

	or

	> Right click on the project **"ZendeskSearch"** and choose "Debug" =>  "Start New Instance".

## Run Unit Tests:

Right click on the project **"ZendeskSearchUnitTest"** and choose "Run Tests".

## Assumptions and Constraints

1. Searching value is based on string comparison (case in-sensitive) so the assumption is that values of all fields can be represented as string, in other words they should all have a default "ToString()" implementation in C#.

2. There are two exceptions to the above, which are fields of type **date** and **array**.

	For date we convert the user input to C# type DateTime and compare with the data record.
	
	For array we assume that every item within the array can be represented in string and searching again is based on string comparison.
	
	The program does not support embedded object types (complex object types within fields), we can possibly update our search algorithm to facilitate that by using some RECURSIVE approach.
	
3. The program starts with the top level menu for selecting one option out of 3:

	* Press 1 to search Zendesk
	* Press 2 to view a list of search fields
	* Type 'quit' to exit
	
	The user will exit the program after selected option 3.
	
	The user will stay within this menu after selected option 2.
	
	The user will not be able to come back to this main memu once selected option 1, which enters to the Search Program. The program has been made in this way since there is no such requirement mentioned, to implement jumping between different levels of menus, we will need to extend the interface below:
	
	* ISearchController