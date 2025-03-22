# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
# Install curl
RUN apt-get update && apt-get install -y curl && rm -rf /var/lib/apt/lists/*
WORKDIR /app
EXPOSE 8080


# This stage is used to build the service project.
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Catering.WebAPI/Catering.WebAPI.csproj", "Catering.WebAPI/"]
COPY ["Catering.Application/Catering.Application.csproj", "Catering.Application/"]
COPY ["Catering.Domain/Catering.Domain.csproj", "Catering.Domain/"]
COPY ["Catering.Infrastructure/Catering.Infrastructure.csproj", "Catering.Infrastructure/"]
RUN dotnet restore "./Catering.WebAPI/Catering.WebAPI.csproj"
COPY . .
WORKDIR "/src/Catering.WebAPI"
RUN dotnet build "./Catering.WebAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Catering.WebAPI.csproj" -c %BUILD_CONFIGURATION% -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catering.WebAPI.dll"]