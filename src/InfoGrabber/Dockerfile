# Build UI
FROM node:22 AS build-ui

WORKDIR /app

COPY client/package*.json ./
RUN npm ci

COPY client/. ./
RUN npm run build

# Build Web Api
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

WORKDIR /app
EXPOSE 5000 5173

COPY src/InfoGrabber/InfoGrabber.csproj ./
RUN dotnet restore InfoGrabber.csproj

COPY src/InfoGrabber/. ./
RUN dotnet build InfoGrabber.csproj -c Debug -o /app/build

ENTRYPOINT ["dotnet", "InfoGrabber.dll"]
