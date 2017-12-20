# Migrations

### Create initial migration
When there is no database and no migrations directory run below 
command in the commandpromp in the directory of your executable project.

You can't run this command from the Data project, because this is a class library.

This will create the Migrations directory with an snapshot and initial datamodel in the Data project.
````
dotnet ef migrations add Initial --project ../alpacashow.data
````
### Create database and tables
Run below programm to create the database and tables
````
dotnet ef database update
````
### Seed the database
Start the programm to seed the database with the initial data.
