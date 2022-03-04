#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT="development"
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["LearnCert.Api/LearnCert.Api.csproj", "LearnCert.Api/"]
RUN dotnet restore "LearnCert.Api/LearnCert.Api.csproj"
COPY . .
WORKDIR "/src/LearnCert.Api"
RUN dotnet build "LearnCert.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearnCert.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnCert.Api.dll"]