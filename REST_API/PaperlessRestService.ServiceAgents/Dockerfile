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

RUN apt-get update && apt-get install -y \
    libleptonica-dev \
    libtesseract-dev \
    imagemagick \
    ghostscript \
    tesseract-ocr \
    libtesseract-dev \
    tesseract-ocr-eng \
    tesseract-ocr-deu

RUN mkdir -p /app/runtimes/linux-x64/native/
RUN ln -s /usr/lib/x86_64-linux-gnu/libdl.so.2 /usr/lib/x86_64-linux-gnu/libdl.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libdl.so.2 /app/runtimes/linux-x64/native/libdl.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libdl.so.2 /app/libdl.so
RUN mkdir /app/x64
RUN ln -s /usr/lib/x86_64-linux-gnu/liblept.so.5 /app/x64/libleptonica-1.82.0.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.5 /app/x64/libtesseract50.so

WORKDIR /app/PaperlessRestService.ServiceAgents/
RUN dotnet build "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaperlessRestService.ServiceAgents.dll"]