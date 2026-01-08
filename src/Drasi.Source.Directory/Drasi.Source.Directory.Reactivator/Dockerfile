FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Drasi.Source.Directory.Reactivator/Drasi.Source.Directory.Reactivator.csproj", "Drasi.Source.Directory.Reactivator/"]
RUN dotnet restore "Drasi.Source.Directory.Reactivator/Drasi.Source.Directory.Reactivator.csproj"
COPY . .
WORKDIR "/src/Drasi.Source.Directory.Reactivator"
RUN dotnet build "./Drasi.Source.Directory.Reactivator.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Drasi.Source.Directory.Reactivator.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Drasi.Source.Directory.Reactivator.dll"]
