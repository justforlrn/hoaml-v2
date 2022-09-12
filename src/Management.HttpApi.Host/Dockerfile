#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NuGet.Config", "."]
COPY ["src/Management.HttpApi.Host/Management.HttpApi.Host.csproj", "src/Management.HttpApi.Host/"]
COPY ["src/Management.Application/Management.Application.csproj", "src/Management.Application/"]
COPY ["src/Management.Application.Contracts/Management.Application.Contracts.csproj", "src/Management.Application.Contracts/"]
COPY ["src/Management.Domain.Shared/Management.Domain.Shared.csproj", "src/Management.Domain.Shared/"]
COPY ["src/Management.Domain/Management.Domain.csproj", "src/Management.Domain/"]
COPY ["src/Management.EntityFrameworkCore/Management.EntityFrameworkCore.csproj", "src/Management.EntityFrameworkCore/"]
COPY ["src/Management.HttpApi/Management.HttpApi.csproj", "src/Management.HttpApi/"]
RUN dotnet restore "src/Management.HttpApi.Host/Management.HttpApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Management.HttpApi.Host"
RUN dotnet build "Management.HttpApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Management.HttpApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Management.HttpApi.Host.dll"]