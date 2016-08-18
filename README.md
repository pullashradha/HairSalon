# Hair Salon Webpage

#### CSharp Database Basics Independent Project for Epicodus, 07/15/2016

#### By Shradha Pulla

## Description

This program is a web application designed for managing a hair salon. It will allow the owner to add stylists to a list, add clients for each stylist, and store the information. The program will also allow for basic data manipulation such as: removing a stylist from the salon database, removing a client from a stylist's records, and deleting all stylists and clients.

## Setup/Installation Requirements

This program can only be accessed on a PC with Windows 10, and with Git, Atom, and Sql Server Management Studio (SSMS) installed.

* Clone this repository
* Import the database and test database:
  * Open SSMS
  * Select the following buttons from the top nav bar to open the database scripts file: File>Open>File>"Desktop\HairSalon\SqlDatabases\hair_salon.sql"
  * Save the hair_salon.sql file
  * To create the database: click the "!Execute" button on the top nav bar
  * To create the database another way, type the following into the top of the sql file:
    * CREATE DATABASE hair_salon;
    * GO
  * Refresh SSMS
  * Repeat the above steps to import the test database
* Test the program:
  * Type following command into PowerShell > dnx test
  * All tests should be passing, if not run dnx test again. Otherwise, fix the errors before launching the program on the browser.
* View the web page:
  * Type following command into PowerShell > dnx kestrel
  * Open Chrome and type in the following address: localhost:5004

## Database Creation Instructions

To build the databases from scratch, type the commands below in the Windows PowerShell:
  * Desktop> SQLCMD -S "[Server-Name]";
    * 1> CREATE DATABASE hair_salon;
    * 2> GO
    * 3> USE hair_salon;
    * 4> GO
    * 5> CREATE TABLE stylists
    * 6>  (
    * 7>  id INT IDENTITY(1,1),
    * 8>  first_name VARCHAR(255),
    * 9>  last_name VARCHAR(255),
    * 10> phone_number VARCHAR(255),
    * 11> email VARCHAR(255),
    * 12> street_address VARCHAR(500),
    * 13> city_address VARCHAR(255),
    * 14> state_address VARCHAR(255),
    * 15> zipcode VARCHAR(255)
    * 16> );
    * 17> GO
    * 18> CREATE TABLE clients
    * 19> (
    * 20> id INT IDENTITY(1,1),
    * 21> first_name VARCHAR(255),
    * 22> last_name VARCHAR(255),
    * 23> phone_number VARCHAR(255),
    * 24> email VARCHAR(255),
    * 25> stylist_id INT
    * 26> );
    * 27> GO
  * Exit out of SQLCMD by typing> QUIT
  * Open SSMS, click open Databases folder and check that the hair_salon database has been created
  * Click "New Query" button on top nav bar (above "!Execute")
  * Type following command into query text space to backup database: BACKUP DATABASE hair_salon TO DISK = 'C:\Users\[Account-Name]\hair_salon.bak'
  * Click "!Execute"
  * Right click hair_salon in the Databases folder: Tasks>Restore>Database
  * Confirm that there is a database to restore in the "Backup sets to restore" option field
  * Under the "Destination" input form, change the database name to: "hair_salon_test"
  * Click "OK", refresh SSMS, and view the new test database in the Database folder

If SQL is not connected in the PowerShell, open SSMS and click the "New Query" button (in nav bar above "!Execute"). Type commands shown above into the text space, starting from "CREATE DATABASE...".

## Known Bugs

No known bugs.

## Specifications

The program should... | Example Input | Example Output
----- | ----- | -----
Add stylist to database in stylists table | Stylist: Terry Jones | Current Stylist: "Terry Jones"
Return correct page for stylist when the stylist's name is clicked on | User clicks on "Terry Jones" on index.cshtml | "Terry Jones", "call for appointments"
Update stylist information | Terry Jones: "101 SW Washington St.", update address | Terry Jones: "2222 E Kones Blvd."
View all stylists in the salon | Current Stylists: none, user adds stylist| Current Stylists: "Terry Jones"
Delete one stylist & corresponding clients from database | Current Stylist: "Terry Jones" & "Paige Davidson", Terry Jones' Clients: "Maya Reddy", Paige Davidson's Clients: "Rubab Shah" | Current Stylists: "Paige Davidson", Paige Davidson's Clients: "Rubab Shah"
Delete all stylists & corresponding clients from database | Current Stylist: "Terry Jones" & "Paige Davidson", Terry Jones' Clients: "Maya Reddy", Paige Davidson's Clients: "Rubab Shah" | Current Stylists: none
Add client to database under a specific stylist | Client: "Maya Reddy" | Terry Jones' Clients: "Maya Reddy"
Update client information | Client: "Jennifer Smith", change last name | Client: "Jennifer James"
View all clients for each individual stylist | Terry Jones' Clients: none, user adds client | Terry Jones' Clients: "Maya Reddy"
Delete one client from a stylist's records | Terry Jones' Clients: "Maya Reddy" & "Rubab Shah", user deletes client| Terry Jones' Clients: "Rubab Shah"

## Future Features

HTML | CSS | C#
----- | ----- | -----
--- | --- | Allow user to delete all clients from stylist but not the stylist

## Support and Contact Details

Contact Epicodus for support in running this program.

## Technologies Used

* HTML
* CSS
* Bootstrap
* C#

## Links

Git Hub Repository: https://github.com/pullashradha/HairSalon

## License

*This software is licensed under the Microsoft ASP.NET license.*

Copyright (c) 2016 Shradha Pulla
