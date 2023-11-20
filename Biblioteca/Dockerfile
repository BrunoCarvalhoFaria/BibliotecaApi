#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Biblioteca/Biblioteca.Api.csproj", "Biblioteca/"]
COPY ["Biblioteca.Application/Biblioteca.Application.csproj", "Biblioteca.Application/"]
COPY ["Biblioteca.Domain.Core/Biblioteca.Domain.Core.csproj", "Biblioteca.Domain.Core/"]
COPY ["Biblioteca.Infra.Data/Biblioteca.Infra.Data.csproj", "Biblioteca.Infra.Data/"]
COPY ["Biblioteca.Domain/Biblioteca.Domain.csproj", "Biblioteca.Domain/"]
COPY ["Biblioteca.Infra.CrossCutting.Identity/Biblioteca.Infra.CrossCutting.Identity.csproj", "Biblioteca.Infra.CrossCutting.Identity/"]
COPY ["Biblioteca.Infra.CrossCutting.IoC/Biblioteca.Infra.CrossCutting.IoC.csproj", "Biblioteca.Infra.CrossCutting.IoC/"]
RUN dotnet restore "Biblioteca/Biblioteca.Api.csproj"
COPY . .
WORKDIR "/src/Biblioteca"
RUN dotnet build "Biblioteca.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Biblioteca.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Biblioteca.Api.dll"]