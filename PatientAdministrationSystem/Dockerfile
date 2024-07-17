# Use the official ASP.NET Core runtime as a parent image
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Use the official ASP.NET Core SDK as a build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PatientAdministrationSystem.API/PatientAdministrationSystem.API.csproj", "PatientAdministrationSystem.API/"]
COPY ["PatientAdministrationSystem.Application/PatientAdministrationSystem.Application.csproj", "PatientAdministrationSystem.Application/"]
COPY ["PatientAdministrationSystem.Infra/PatientAdministrationSystem.Infra.csproj", "PatientAdministrationSystem.Infra/"]
RUN dotnet restore "PatientAdministrationSystem.API/PatientAdministrationSystem.API.csproj"
COPY . .
WORKDIR "/src/PatientAdministrationSystem.API"
RUN dotnet build "PatientAdministrationSystem.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientAdministrationSystem.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PatientAdministrationSystem.API.dll"]