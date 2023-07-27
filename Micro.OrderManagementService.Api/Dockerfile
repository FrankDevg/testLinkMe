#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Micro.OrderManagementService.Api/Micro.OrderManagementService.Api.csproj", "Micro.OrderManagementService.Api/"]
COPY ["Micro.OrderManagementService.Application/Micro.OrderManagementService.Application.csproj", "Micro.OrderManagementService.Application/"]
COPY ["Micro.OrderManagementService.Infraestructure/Micro.OrderManagementService.Infraestructure.csproj", "Micro.OrderManagementService.Infraestructure/"]
COPY ["Micro.OrderManagementService.Domain/Micro.OrderManagementService.Domain.csproj", "Micro.OrderManagementService.Domain/"]
RUN dotnet restore "Micro.OrderManagementService.Api/Micro.OrderManagementService.Api.csproj"
COPY . .
WORKDIR "/src/Micro.OrderManagementService.Api"
RUN dotnet build "Micro.OrderManagementService.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Micro.OrderManagementService.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Micro.OrderManagementService.Api.dll"]