#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["boatappapi.csproj", ""]
RUN dotnet restore
COPY . .
WORKDIR "/src/."
RUN dotnet build "./boatappapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./boatappapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "boatappapi.dll"]
