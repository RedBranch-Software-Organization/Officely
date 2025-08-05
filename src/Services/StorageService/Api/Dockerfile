# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Nuget.Config", "."]
COPY ["src/Services/StorageService/Api/Api.csproj", "src/Services/StorageService/Api/"]
COPY ["src/Services/CodeService/Api.Client/Api.Client.csproj", "src/Services/CodeService/Api.Client/"]
COPY ["src/Services/StorageService/Application/Application.csproj", "src/Services/StorageService/Application/"]
COPY ["src/BuildingBlocks/IntegrationEvents/IntegrationEvents.csproj", "src/BuildingBlocks/IntegrationEvents/"]
COPY ["src/Services/StorageService/Infrastructure/Infrastructure.csproj", "src/Services/StorageService/Infrastructure/"]
COPY ["src/Services/StorageService/Domain/Domain.csproj", "src/Services/StorageService/Domain/"]
RUN dotnet nuget add source --username 'Rawenvoys' --password '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' --store-password-in-clear-text --name RedBranch-Software-Organization "https://nuget.pkg.github.com/RedBranch-Software-Organization/index.json"
RUN dotnet restore "./src/Services/StorageService/Api/Api.csproj"
COPY . .
WORKDIR "/src/src/Services/StorageService/Api"
RUN dotnet build "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Officely.StorageService.Api.dll"]