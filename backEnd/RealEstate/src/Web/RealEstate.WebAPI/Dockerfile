#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Web/RealEstate.WebAPI/RealEstate.WebAPI.csproj", "src/Web/RealEstate.WebAPI/"]
COPY ["src/Bootstrapper/Bootstrapper.csproj", "src/Bootstrapper/"]
COPY ["src/Infrastructure/Persistence/Persistence.csproj", "src/Infrastructure/Persistence/"]
COPY ["src/Core/RealEstate.Domain/RealEstate.Domain.csproj", "src/Core/RealEstate.Domain/"]
COPY ["src/Common/Common.csproj", "src/Common/"]
COPY ["src/Core/RealEstate.Application/RealEstate.Application.csproj", "src/Core/RealEstate.Application/"]
RUN dotnet restore "src/Web/RealEstate.WebAPI/RealEstate.WebAPI.csproj"
COPY . .
WORKDIR "/src/src/Web/RealEstate.WebAPI"
RUN dotnet build "RealEstate.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RealEstate.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RealEstate.WebAPI.dll"]
