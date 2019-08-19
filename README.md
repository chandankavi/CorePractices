# CorePractices
Project Title
It's a simple web api developed with .net core 

Getting Started
Project is built in Visual Studio 2019 .net core version 2.1

Folder Structre
Solution consists of 5 project as below
#3 Class libraries
  1.Evolent.BusinessLayer
  2.Evolent.DataAccessLayer
  3.Evolent.Models
#Main project 
  1.EvolentContact
#XUnit test project 
  1.EvolentContactTest
  
Nuget Packages used
1.Microsoft.EntityFrameworkCore
2.Microsoft.EntityFrameworkCore.SqlServer
3.Microsoft.EntityFrameworkCore.InMemory
  
Steps to run the dev. environment

1.Build the solution with required .net core dependancies
2.Set EvolentContact as startup project
3.Use Postman or Fidller to test the URI's
4.You can also use unit tests to test the API with dummy json already created in EvolentContactTest project
