# Dockerfile for .NET Web API
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
COPY ["webapi.csproj", "./"]
RUN dotnet restore "./webapi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "webapi.csproj" -c Release -o /app/build
RUN dotnet ef migrations add CoolifyCreate
RUN dotnet ef database update

FROM build AS publish
RUN dotnet publish "webapi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "webapi.dll"]