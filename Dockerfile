# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy project file and restore
COPY LayerApi.csproj ./
RUN dotnet restore LayerApi.csproj

# Copy the entire source and publish
COPY . ./
RUN dotnet publish LayerApi.csproj -c Release -o out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

ENTRYPOINT ["dotnet", "LayerApi.dll"]
