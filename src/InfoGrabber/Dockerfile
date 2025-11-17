# Stage 1 — build the React app
FROM node:18-alpine AS build-frontend
WORKDIR /src/client
COPY client/package*.json ./
RUN npm ci
COPY client/ ./
RUN npm run build

# Stage 2 — build the .NET app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-backend
WORKDIR /src
COPY *.sln ./
COPY src/InfoGrabber/*.csproj ./src/InfoGrabber/
RUN dotnet restore
COPY . .
RUN dotnet publish ./src/InfoGrabber/ -c Release -o /app/publish

# Stage 3 — runtime image with frontend files copied into wwwroot
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build-backend /app/publish .
# Adjust path below if your React build output folder is different (e.g. build vs dist)
COPY --from=build-frontend /src/client/dist ./wwwroot
ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80
ENTRYPOINT ["dotnet", "InfoGrabber.dll"]
