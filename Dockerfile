#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT="development"
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

COPY ["LearnCert.Application/LearnCert.Application.csproj", "LearnCert.Application/"]
COPY ["LearnCert.Domain/LearnCert.Domain.csproj", "LearnCert.Domain/"]
COPY ["LearnCert.API/LearnCert.API.csproj", "LearnCert.API/"]

RUN dotnet restore "LearnCert.Application/LearnCert.Application.csproj"

COPY . .

RUN dotnet build "LearnCert.Application/LearnCert.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LearnCert.Application/LearnCert.Application.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LearnCert.Application.dll"]