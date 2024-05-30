# Use the official image as a parent image.
FROM mcr.microsoft.com/dotnet/sdk:8.0-noble AS build-env

# Set the working directory.
WORKDIR /app

# Copy csproj and restore dependencies
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the working directory contents into the container at /app.
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-noble-chiseled
WORKDIR /app
COPY --from=build-env /app/out .

# Expose port 80
EXPOSE 80

# Run the application
ENTRYPOINT ["dotnet", "YourApplication.dll"]
