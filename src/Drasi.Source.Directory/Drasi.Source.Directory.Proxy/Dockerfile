FROM mcr.microsoft.com/dotnet/runtime:10.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Drasi.Source.Directory.Proxy/Drasi.Source.Directory.Proxy.csproj", "Drasi.Source.Directory.Proxy/"]
RUN dotnet restore "Drasi.Source.Directory.Proxy/Drasi.Source.Directory.Proxy.csproj"
COPY . .
WORKDIR "/src/Drasi.Source.Directory.Proxy"
RUN dotnet build "./Drasi.Source.Directory.Proxy.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Drasi.Source.Directory.Proxy.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Drasi.Source.Directory.Proxy.dll"]
