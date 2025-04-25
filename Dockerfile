# Use SDK image to build app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy everything into the container
COPY . .

# Restore dependencies using the correct path to the project file
RUN dotnet restore "AKBrandMobile.csproj"

# Build and publish the app
RUN dotnet publish "AKBrandMobile.csproj" -c Release -o /app/out

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/out .

EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

ENTRYPOINT ["dotnet", "AKBrandMobile.dll"]
