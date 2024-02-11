#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8093


FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Venta.Worker/Venta.Worker.csproj", "Venta.Worker/"]
COPY ["VentaWorker.Application/VentaWorker.Application.csproj", "VentaWorker.Application/"]
COPY ["VentaWorker.Domain/VentaWorker.Domain.csproj", "VentaWorker.Domain/"]
COPY ["VentaWorker.Infrastructure/VentaWorker.Infrastructure.csproj", "VentaWorker.Infrastructure/"]
RUN dotnet restore "./Venta.Worker/./Venta.Worker.csproj"
COPY . .
WORKDIR "/src/Venta.Worker"
RUN dotnet build "./Venta.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Venta.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Venta.Worker.dll"]