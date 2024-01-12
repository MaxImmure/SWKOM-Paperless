#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PaperlessRestService/PaperlessRestService.csproj", "PaperlessRestService/"]
COPY ["PaperlessRestService.BusinessLogic/PaperlessRestService.BusinessLogic.csproj", "PaperlessRestService.BusinessLogic/"]
COPY ["PaperlessRestService.BusinessLogic.Entities/PaperlessRestService.BusinessLogic.Entities.csproj", "PaperlessRestService.BusinessLogic.Entities/"]
COPY ["PaperlessRestService.BusinessLogic.Interfaces/PaperlessRestService.BusinessLogic.Interfaces.csproj", "PaperlessRestService.BusinessLogic.Interfaces/"]
RUN dotnet restore "PaperlessRestService/PaperlessRestService.csproj"
COPY . .
WORKDIR "/src/PaperlessRestService"
RUN dotnet build "PaperlessRestService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaperlessRestService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaperlessRestService.dll"]