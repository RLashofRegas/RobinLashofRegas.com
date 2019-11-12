FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM node:latest as node-build
WORKDIR /node-build/ClientApp
COPY src/webspa/ClientApp .
RUN npm install
RUN npm run build

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS dotnet-build
WORKDIR /dotnet-build
COPY /src/webspa .
COPY --from=node-build /node-build .
RUN dotnet restore webspa.csproj

FROM dotnet-build AS publish
WORKDIR /dotnet-build
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webspa.dll"]
