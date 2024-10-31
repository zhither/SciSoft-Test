# Build Stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src

# Copy and restore dependencies
COPY src/*.csproj ./
RUN dotnet restore

# Copy the rest of the source code
COPY src/. ./

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Runtime Stage
FROM mcr.microsoft.com/dotnet/runtime:8.0

WORKDIR /app

# Copy the published application from the build stage
COPY --from=build /app/publish .

# Run the application
ENTRYPOINT ["dotnet", "src.dll"]
