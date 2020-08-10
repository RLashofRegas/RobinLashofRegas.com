FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS dotnet-build
WORKDIR /build
COPY /nuget.config /
COPY /src/services/BlogAPI .
RUN dotnet restore BlogAPI.csproj
RUN dotnet build BlogAPI.csproj -c Release -o /app

FROM dotnet-build AS publish
WORKDIR /build
RUN dotnet publish BlogAPI.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "BlogAPI.dll"]
