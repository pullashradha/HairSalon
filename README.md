# Hair Salon Webpage

#### CSharp Database Basics Independent Project for Epicodus, 07/15/2016

#### By Shradha Pulla

## Description

This program is a web application designed for managing a hair salon. It will allow the owner to add stylists to a list, add clients for each stylist, and store the information. The program will also allow for basic data manipulation such as: removing a stylist from the salon database, removing a client from a stylist's registry, and changing a client's stylist.

## Setup/Installation Requirements

This program can only be accessed on a PC with Windows 10, and with Git, Atom, and Sql Server Management Studio (SSMS) installed.

* Clone this repository
* Import the database and test database:
  * Open SSMS
  * Select the following buttons from the top nav bar to open the database scripts file: File>Open>File>"Desktop\HairSalon\SqlDatabases\hair_salon.sql"
  * Save the hair_salon.sql file
  * To create the database: click the "!Execute" button on the top nav bar
  * Repeat the above steps to import the test database
* View the web page:
  * Type following command into PowerShell > dnx kestrel
  * Open Chrome and type in the following address: localhost:5004

## Known Bugs

* Deleting a Stylist through the web page does not delete all respective clients under that Stylist in the database
* Id numbers for the Stylists and Clients do not reset after previous entries are deleted from the database
* CSS styling is not functioning on all the pages, aside from index.cshtml

## Specifications

The program should ... | Example Input | Example Output
----- | ----- | -----
Add stylist to database in stylists table | --- | ---
Add client to database under a specific stylist's registry/category | --- | ---
View all stylists in the salon | --- | ---
View all clients for each individual stylist | --- | ---
Delete a stylist & corresponding clients from database | --- | ---
Delete a client from a stylist's registry, without deleting other clients | --- | ---

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
