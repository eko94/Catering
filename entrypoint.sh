#!/bin/bash
set -e

# Run EF migrations
dotnet ef database update --project "./Catering.Infrastructure/Catering.Infrastructure.csproj" --startup-project "./Catering.WebAPI/Catering.WebAPI.csproj" --context StoredDbContext

# Start the application
exec dotnet Catering.WebAPI.dll