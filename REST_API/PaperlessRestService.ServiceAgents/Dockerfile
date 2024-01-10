#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app
EXPOSE 8000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PaperlessRestService.ServiceAgents/PaperlessRestService.ServiceAgents.csproj", "PaperlessRestService.ServiceAgents/"]
COPY ["PaperlessRestService.BusinessLogic.DataAccess/PaperlessRestService.BusinessLogic.DataAccess.csproj", "PaperlessRestService.BusinessLogic.DataAccess/"]
COPY ["PaperlessRestService.BusinessLogic.Entities/PaperlessRestService.BusinessLogic.Entities.csproj", "PaperlessRestService.BusinessLogic.Entities/"]
COPY ["PaperlessRestService.ServiceAgents.Interfaces/PaperlessRestService.ServiceAgents.Interfaces.csproj", "PaperlessRestService.ServiceAgents.Interfaces/"]
RUN dotnet restore "PaperlessRestService.ServiceAgents/PaperlessRestService.ServiceAgents.csproj"
COPY . .
WORKDIR "/src/PaperlessRestService.ServiceAgents"

RUN apt-get update -y && apt-get install -y libc6-dev libleptonica-dev
RUN apt-get update -y && apt-get install -y wget gnupg2 apt-transport-https software-properties-common

RUN tee /etc/apt/sources.list.d/notesalexp.list<<EOF
RUN echo "deb https://notesalexp.org/tesseract-ocr5/$(lsb_release -cs)/ $(lsb_release -cs) main" | tee /etc/apt/sources.list.d/notesalexp.list > /dev/null
RUN wget -O - https://notesalexp.org/debian/alexp_key.asc | apt-key add - 

RUN apt-get update -y && apt-get install -y tesseract-ocr
RUN apt-get update -y && apt-get install -y ghostscript

RUN dotnet build "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaperlessRestService.ServiceAgents.dll"]