#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/StationManagerApi/StationManagerApi.csproj", "src/StationManagerApi/"]
COPY ["src/HttpUtility/HttpUtility.csproj", "src/HttpUtility/"]
RUN dotnet restore "src/StationManagerApi/StationManagerApi.csproj"
COPY . .
WORKDIR "/src/src/StationManagerApi"
RUN dotnet build "StationManagerApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StationManagerApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StationManagerApi.dll"]