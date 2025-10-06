FROM mcr.microsoft.com/dotnet/runtime:9.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["KPI4Lab1/KPI4Lab1.csproj", "KPI4Lab1/"]
RUN dotnet restore "KPI4Lab1/KPI4Lab1.csproj"
COPY . .
WORKDIR "/src/KPI4Lab1"
RUN dotnet build "./KPI4Lab1.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./KPI4Lab1.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KPI4Lab1.dll"]
