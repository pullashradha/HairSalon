# Hair Salon Webpage

#### CSharp Database Basics Independent Project for Epicodus, 07/15/2016

#### By Shradha Pulla

## Description

This program is a web application designed for managing a hair salon. It will allow the owner to add stylists to a list, add clients for each stylist, and store the information. The program will also allow for basic data manipulation such as: removing a stylist from the salon database, removing a client from a stylist's registry, and deleting all stylists and clients.

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
  * All tests should be passing, if not run dnx test again
* View the web page:
  * Type following command into PowerShell > dnx kestrel
  * Open Chrome and type in the following address: localhost:5004

## Known Bugs

No known bugs.

## Specifications

The program should ... | Example Input | Example Output
----- | ----- | -----
Add stylist to database in stylists table | Stylist: Terry Jones | Current Stylist: "Terry Jones"
Return correct page for stylist when the stylist's name is clicked on | User clicks on "Terry Jones" on index.cshtml | "Terry Jones", "call for appointments"
View all stylists in the salon | Current Stylists: none, user adds stylist| Current Stylists: "Terry Jones"
Delete one stylist & corresponding clients from database, without deleting other stylists | Current Stylist: "Terry Jones" & "Paige Davidson", Terry Jones' Clients: "Maya Reddy", Paige Davidson's Clients: "Rubab Shah" | Current Stylists: "Paige Davidson", Paige Davidson's Clients: "Rubab Shah"
Delete all stylists & corresponding clients from database | Current Stylist: "Terry Jones" & "Paige Davidson", Terry Jones' Clients: "Maya Reddy", Paige Davidson's Clients: "Rubab Shah" | Current Stylists: none
Add client to database under a specific stylist | Client: "Maya Reddy" | Terry Jones' Clients: "Maya Reddy"
View all clients for each individual stylist on stylist.cshtml | Terry Jones' Clients: none, user adds client | Terry Jones' Clients: "Maya Reddy"
Delete one client from a stylist's registry, without deleting other clients | Terry Jones' Clients: "Maya Reddy" & "Rubab Shah", user deletes client| Terry Jones' Clients: "Rubab Shah"

## Future Features

HTML | CSS | C#
----- | ----- | -----
----- | ----- | -----

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
