# Use SDK image to build app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything and restore
COPY . ./
WORKDIR /src/AKBrandMobile
RUN dotnet restore

# Publish the application
RUN dotnet publish -c Release -o /app/out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Copy published output
COPY --from=build /app/out .

# Set environment and expose port
ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Start the app
ENTRYPOINT ["dotnet", "AKBrandMobile.dll"]
