FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Services/Auth/API/API.csproj", "Services/Auth/API/"]
COPY ["Services/Auth/Application/Application.csproj", "Services/Auth/Application/"]
COPY ["Services/Auth/Domain/Domain.csproj", "Services/Auth/Domain/"]
COPY ["Services/Auth/Infrastructure/Infrastructure.csproj", "Services/Auth/Infrastructure/"]
RUN dotnet restore "Services/Auth/API/API.csproj"
COPY . .
WORKDIR "/src/Services/Auth/API"
RUN dotnet build "API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "API.dll"]
