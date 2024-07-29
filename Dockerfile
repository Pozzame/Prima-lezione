FROM mcr.microsoft.com/dotnet/runtime:8.0-nanoserver-1809 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Prima lezione/Prima lezione.csproj", "Prima lezione/"]
RUN dotnet restore "Prima lezione\Prima lezione.csproj"
COPY . .
WORKDIR "/src/Prima lezione"
RUN dotnet build "Prima lezione.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Prima lezione.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Prima lezione.dll"]
