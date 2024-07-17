# Patient Administration System

Welcome to the Patient Administration System solution. This repository contains both the back-end Web API and the front-end Angular application. 

The system allows users to manage patient information and their hospital visits efficiently.

## Features:-

### Web API
- **Patient Management**: Search for patients by their first name, last name, or email.
- **Hospital Visit Management**: Track and manage patient hospital visits.
- **Data Access**: Utilizes Entity Framework Core for data access.

### Angular Front-end
- **Patient Search**: Provides a user-friendly interface to search for patient details.

## Solution Structure

The solution is structured as follows:

PatientAdministrationSystem
├── PatientAdministrationSystem.sln
├── PatientAdministrationSystem.Application
│ ├── PatientAdministrationSystem.Application.csproj
├── PatientAdministrationSystem.Infra
│ ├── PatientAdministrationSystem.Infra.csproj
├── PatientAdministrationSystem.API
│ ├── Dockerfile
│ ├── PatientAdministrationSystem.API.csproj
│ ├── Program.cs
│ ├── Controllers
│ ├── Models
├── PatientAdministrationSystem.Tests
│ ├── PatientAdministrationSystem.Tests.csproj
├── PatientAdministrationSystem.UI
│ ├── Dockerfile
│ ├── angular.json
│ ├── package.json
│ ├── src
└── docker-compose.yml

## Prerequisites

- .NET 8.0 or later
- Node.js and npm
- Docker


## Setup Instructions


1. Running the Back-end Only (Web API)
2. Open the solution: PatientAdministrationSystem.sln in Visual Studio.
3. Restore NuGet packages: Build the solution to restore all NuGet packages.
4. Run the Web API project (PatientAdministrationSystem.API).
5. Access the API: Open your browser and navigate to http://localhost:5272/swagger/.


### Front-end (Angular)

1. Navigate to the `PatientAdministrationSystem.UI` directory.
2. Install Angular CLI globally if not already installed:
   ```sh
   npm install -g @angular/cli
   
3. Install project dependencies
     npm install
	 
4. Run the Angular application:
    ng serve
	
5. Open your browser and navigate to http://localhost:4200.

### Running Test (Angular)

Back-end Tests:-
Open the PatientAdministrationSystem.sln in Visual Studio.
Run the tests in the PatientAdministrationSystem.Tests project using the Test Explorer.

You can also try running the application alternatively through Docker :-

### Running the Full Application with Docker Compose

This method will run both the back-end Web API and the front-end Angular application together.

1. **Ensure Docker is installed and running**.
2. **Clone the repository**:
3. Build and run the containers
   docker-compose up --build
4. Access the applications:
	Angular Application: Open your browser and navigate to http://localhost:4200.
	ASP.NET Core Web API: Open your browser and navigate to http://localhost:5272/swagger.


