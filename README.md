# Patient Administration System

Welcome to the Patient Administration System solution. This repository contains both the back-end Web API and the front-end React application. 

The system allows users to manage patient information and their hospital visits efficiently.

## Features:-

### Web API
- **Patient Management**: Search for patients by their first name, last name, or email.
- **Hospital Visit Management**: Track and manage patient hospital visits.
- **Data Access**: Utilizes Entity Framework Core for data access.

### React Front-end

- **Patient Search**: Provides a user-friendly interface to search for patient details.
- **Result Display**: Displays patient details and visit information in a table format.
- **Validation**: Ensures search input is valid and displays appropriate error messages.

## Solution Structure

The solution is structured as follows:

PatientAdministrationSystem/
├── PatientAdministrationSystem.sln
├── PatientAdministrationSystem.Application/
│   ├── PatientAdministrationSystem.Application.csproj
├── PatientAdministrationSystem.Infra/
│   ├── PatientAdministrationSystem.Infra.csproj
├── PatientAdministrationSystem.API/
│   ├── Dockerfile
│   ├── PatientAdministrationSystem.API.csproj
│   ├── Program.cs
│   ├── Controllers/
│   ├── Models/
├── PatientAdministrationSystem.Tests/
│   ├── PatientAdministrationSystem.Tests.csproj
├── PatientAdministrationSystem.UI/
│   ├── Dockerfile
│   ├── .env
│   ├── .env.production
│   ├── package.json
│   ├── src/
│   │   ├── components/
│   │   │   ├── Header.tsx
│   │   │   ├── PatientSearchBar.tsx
│   │   │   ├── SearchResultView.tsx
│   │   ├── patientSearchService.ts
│   │   ├── App.tsx
│   │   ├── index.tsx
│   ├── public/
│   │   ├── index.html
│   ├── tsconfig.json
│   ├── vite.config.ts
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


## Front-end (React)
1. Navigate to the PatientAdministrationSystem.UI directory.
2.  Install the necessary npm packages.
   	npm install
3. Create a .env file in the root of the PatientAdministrationSystem.UI directory with the following content:
   	VITE_API_LOCAL_BASE_URL=http://localhost:5272/api
	VITE_API_REMOTE_BASE_URL=https://patientadminapi.azurewebsites.net/api
4. Start the development server.
   npm run dev
5. Open your browser and navigate to http://localhost:5173.
   

## Running Tests
Back-end Tests:-
1. Open the PatientAdministrationSystem.sln in Visual Studio.
2. Run the tests in the PatientAdministrationSystem.Tests project using the Test Explorer.

Front-end Tests:- 
1. To run the unit tests for the frontend:
   	npm test

You can also try running the application alternatively through Docker :-

### Running the Full Application with Docker Compose

This method will run both the back-end Web API and the front-end React application together.

1. Ensure Docker is installed and running.

2. Clone the repository.

3. Build and run the containers.
	docker-compose up --build
4.Access the applications:
	React Application: Open your browser and navigate to http://localhost:5173.
	ASP.NET Core Web API: Open your browser and navigate to http://localhost:5272/swagger.
