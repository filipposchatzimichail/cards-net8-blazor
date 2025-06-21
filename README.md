# cards-net8-blazor
An application named Cards that allows users to create and manage tasks in the form of cards

# Technologies

* .NET8 & Blazor (Server)
* One AdminApp & one ClientApp
* Real time monitoring of New/Updated/Deleted Cards (Admin live feed)
* MSSQL localdb
* Entity Framework ORM
* Best practices
* Separation of Concerns
* Reusability with Generics
* Authentication, Login, Logout
* Two client accounts (user1@logicea.com with password User123! and user2@logicea.com with password User123!)
* One admin account (admin@logicea.com with password Admin123!)

# Features

* Application users are identified uniquely by their mail address, have a role (Member or Admin) and use a password to authenticate themselves before accessing cards
* Members have access to cards they created
* Admins have access to all cards
* A user creates a card by providing a name for it and, optionally, a description and a color
  * Name is mandatory
  * Color, if provided, should conform to a “6 alphanumeric characters prefixed with a #“ format
  * Upon creation, the status of a card is To Do

* A user can search through cards they have access to
  * Filters include name, color, status and date of creation

* Results may be sorted by name, color, status, date of creation
* A user can request a single card they have access to
* A user can update the name, the description, the color and/or the status of a card they have access to
* Contents of the description and color fields can be cleared out
* Available statuses are To Do, In Progress and Done
* A user can delete a card they have access to
* Seeded sample data of 6 cards (3 for user1 and 3 for user2)
  

To create the database just run the following command from the solution folder (assumes dotnet-ef is globally installed)
`dotnet ef database update --project Logicea.Cards.DataAccess --startup-project Logicea.Cards.AdminApp`
