#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app
COPY ["PaperlessRestService.ServiceAgents/PaperlessRestService.ServiceAgents.csproj", "PaperlessRestService.ServiceAgents/"]
COPY ["PaperlessRestService.BusinessLogic.DataAccess/PaperlessRestService.BusinessLogic.DataAccess.csproj", "PaperlessRestService.BusinessLogic.DataAccess/"]
COPY ["PaperlessRestService.BusinessLogic.Entities/PaperlessRestService.BusinessLogic.Entities.csproj", "PaperlessRestService.BusinessLogic.Entities/"]
COPY ["PaperlessRestService.ServiceAgents.Interfaces/PaperlessRestService.ServiceAgents.Interfaces.csproj", "PaperlessRestService.ServiceAgents.Interfaces/"]
RUN dotnet restore "PaperlessRestService.ServiceAgents/PaperlessRestService.ServiceAgents.csproj"
COPY . .

RUN apt-get update && apt-get install -y ghostscript-x libleptonica-dev libtesseract-dev libc6-dev

WORKDIR /app/x64
RUN ln -s /usr/lib/x86_64-linux-gnu/liblept.so libleptonica-1.82.0.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.4.0.1 libtesseract50.so

WORKDIR /app/PaperlessRestService.ServiceAgents/
RUN dotnet build "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaperlessRestService.ServiceAgents.dll"]