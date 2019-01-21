# PersonalTrainer

[![Build Status](https://dev.azure.com/std100308/Personal%20Trainers/_apis/build/status/jimtsikos.PersonalTrainer?branchName=master)](https://dev.azure.com/std100308/Personal%20Trainers/_build/latest?definitionId=3?branchName=master)

## Requirements

1. Visual Studio 2017
2. .NET Core SDK 2.2
3. Nuget

## Technologies Used:

1. DDD Architecture (still working on it)
2. Entity Framework Core
3. Autofac Dependency Injection
4. Microsoft Identity
5. ASP.NET Core MVC
6. Xamarin Forms
7. NUnit
8. Azure Pipelines

## What you may need to change:

1. appsettings.json -> Change DefaultConnection to your Database Connection String
2. PersonalTrainerWebDbInitializer.cs -> Add/Remove/Change Roles
3. PersonalTrainerWebDbInitializer.cs -> Add/Remove/Change User
4. Program.cs -> Change the CreateWebHostBuilder method based on your needs
5. Run the following commands on Package Manager Control
    * Add-Migration Initial
    * Update-Database

## Milestones (without time)

1. Complete tests
2. Deploy the WebApp
3. Create a docker image of the application
4. Add Xamarin Forms
5. Create CRUD for Xamarin Forms
