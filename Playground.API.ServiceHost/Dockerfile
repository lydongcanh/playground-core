FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Playground.API.ServiceHost/Playground.API.ServiceHost.csproj", "Playground.API.ServiceHost/"]
RUN dotnet restore "Playground.API.ServiceHost/Playground.API.ServiceHost.csproj"
COPY . .
WORKDIR "/src/Playground.API.ServiceHost"
RUN dotnet build "Playground.API.ServiceHost.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Playground.API.ServiceHost.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Playground.API.ServiceHost.dll"]
