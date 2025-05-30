# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore dependencies
COPY LayerApi.csproj ./
RUN dotnet restore

# Copy the rest of the project files
COPY . ./

# Publish the project
RUN dotnet publish -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy the published output from the build stage
COPY --from=build /app/out .

# Run the application
ENTRYPOINT ["dotnet", "LayerApi.dll"]
