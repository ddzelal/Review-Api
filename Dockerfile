# Stage 1 - Build
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Clear NuGet cache
RUN dotnet nuget locals all --clear

# Install Entity Framework CLI
RUN dotnet tool install --global dotnet-ef --version 7.0.0

# Copy csproj and restore as distinct layers
COPY *.csproj .
RUN dotnet restore

# Copy everything else and build
COPY . .
RUN dotnet build -c Release

# Stage 2 - Migrate
FROM build AS migrate
# Add the tool to the PATH
ENV PATH="${PATH}:/root/.dotnet/tools"
# Run migrations
RUN sleep 30
RUN dotnet ef database update

# Stage 3 - Publish
FROM build AS publish
RUN dotnet publish -c Release -o out

# Stage 4 - Final
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS final
WORKDIR /app
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "web-app1.dll"]
