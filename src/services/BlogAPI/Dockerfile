FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS dotnet-build
WORKDIR /src
COPY src/services/BlogAPI/BlogAPI.csproj src/services/BlogAPI/
RUN dotnet restore src/services/BlogAPI/BlogAPI.csproj
COPY . .
WORKDIR /src/src/services/BlogAPI
RUN dotnet build BlogAPI.csproj -c Release -o /app

FROM dotnet-build AS publish
RUN dotnet publish BlogAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlogAPI.dll"]
