# Use the official .NET SDK image for building the app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore any dependencies (via dotnet restore)
COPY FutureValueCalculator/*.csproj ./
RUN dotnet restore

# Copy the rest of the application code
COPY FutureValueCalculator/ ./

# Publish the application to the /out directory
RUN dotnet publish -c Release -o /out

# Use the official .NET runtime image for running the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

# Copy the published output from the build image
COPY --from=build /out .

# Expose port 80 for the application
EXPOSE 80

# Set the entry point for the application
ENTRYPOINT ["dotnet", "FutureValueCalculator.dll"]
