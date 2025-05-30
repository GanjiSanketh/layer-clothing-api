# Base image for runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

# Build image
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copy csproj and restore
COPY ["LayerApi/LayerApi.csproj", "LayerApi/"]
RUN dotnet restore "LayerApi/LayerApi.csproj"

# Copy rest of the code
COPY . .
WORKDIR "/src/LayerApi"
RUN dotnet build "LayerApi.csproj" -c Release -o /app/build

# Publish
FROM build AS publish
RUN dotnet publish "LayerApi.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LayerApi.dll"]
