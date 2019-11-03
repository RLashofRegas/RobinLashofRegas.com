FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY src/webspa/webspa.csproj src/webspa/
RUN dotnet restore src/webspa/webspa.csproj
COPY . .
WORKDIR /src/src/webspa
RUN dotnet build webspa.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish webspa.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webspa.dll"]
