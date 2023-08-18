#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ACME.Store.Presentation/ACME.Store.Presentation.csproj", "ACME.Store.Presentation/"]
COPY ["ACME.Store.Application/ACME.Store.Application.csproj", "ACME.Store.Application/"]
COPY ["ACME.Store.Infrastructure/ACME.Store.Infrastructure.csproj", "ACME.Store.Infrastructure/"]
COPY ["ACME.Store.Domain/ACME.Store.Domain.csproj", "ACME.Store.Domain/"]
RUN dotnet restore "ACME.Store.Presentation/ACME.Store.Presentation.csproj"
COPY . .
WORKDIR "/src/ACME.Store.Presentation"
RUN dotnet build "ACME.Store.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ACME.Store.Presentation.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ACME.Store.Presentation.dll"]