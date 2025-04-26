# Use SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy everything to container
COPY . . 

# Restore and publish using correct .csproj file name
RUN dotnet restore "AkBrandMobile.csproj"
RUN dotnet publish "AkBrandMobile.csproj" -c Release -o /out --no-restore

# Use runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out .

ENV ASPNETCORE_URLS=http://+:8080
EXPOSE 8080

# Correct .dll file name
ENTRYPOINT ["dotnet", "AkBrandMobile.dll"]
