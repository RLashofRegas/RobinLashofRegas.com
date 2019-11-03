FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS dotnet-build
WORKDIR /src

FROM node:latest as node-build
WORKDIR /webspa
COPY src/webspa/ClientApp .
RUN npm install
RUN npm run build

FROM dotnet-build AS publish
WORKDIR /src/src/webspa/ClientApp/dist/webspa
COPY --from=node-build /webspa/dist/webspa .
WORKDIR /src
COPY . .
WORKDIR /src/src/webspa
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "webspa.dll"]
