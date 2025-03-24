FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Interfaces/Interfaces.csproj", "Interfaces/"]
COPY ["Infrastructures/Infrastructures.csproj", "Infrastructures/"]
COPY ["Shares/Shares.csproj", "Shares/"]
COPY ["Cores/Cores.csproj", "Cores/"]
RUN dotnet restore "Interfaces/Interfaces.csproj"
COPY . .
WORKDIR "/src/Interfaces"
RUN dotnet build "Interfaces.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Interfaces.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Interfaces.dll"]
