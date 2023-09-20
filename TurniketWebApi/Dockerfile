FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update \
    && apt-get install -y --no-install-recommends libgdiplus libc6-dev \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TurniketWebApi/TurniketWebApi.csproj", "TurniketWebApi/"]
RUN dotnet restore "TurniketWebApi/TurniketWebApi.csproj"
COPY . .
WORKDIR "/src/TurniketWebApi"
RUN dotnet build "TurniketWebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TurniketWebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TurniketWebApi.dll"]