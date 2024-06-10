# Use the .NET SDK image as the build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy the project files and restore dependencies
COPY . .
RUN dotnet restore "EventDrivenBookstoreAPI.csproj"

RUN dotnet build "EventDrivenBookstoreAPI.csproj" -c release -o /app


FROM mcr.microsoft.com/dotnet/aspnet:8.0 
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5006

ENTRYPOINT ["dotnet", "EventDrivenBookstoreAPI.dll"]
