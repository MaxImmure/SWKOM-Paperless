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
RUN apt-get update -y && apt-get install -y ghostscript libgs-dev

ARG TARGETPLATFORM
RUN if [ "$TARGETPLATFORM" = "linux/amd64" ]; then \
        export ARCHITECTURE="x86_64"; \
        export CPU_BIT="64"; \
    elif [ "$TARGETPLATFORM" = "linux/arm/v7" ]; then \
        export ARCHITECTURE="arm"; \
        export CPU_BIT="32"; \
    elif [ "$TARGETPLATFORM" = "linux/arm64" ]; then \
        ARCHITECTURE="aarch64"; \
    else \
        export ARCHITECTURE=x86; \
        export CPU_BIT=32; \
    fi

RUN if [ "$CPU_BIT" != "64" ]; then \
        if [ "$ARCHITECTURE" != "x86_64" ]; then \
            ln -s /usr/lib/aarch64-linux-gnu /usr/lib/x86_64-linux-gnu; \
        fi \
    fi

RUN ln -s /usr/lib/x86_64-linux-gnu/liblept.so.5 /App/x64/libleptonica-1.82.0.so
RUN ln -s /usr/lib/x86_64-linux-gnu/libtesseract.so.5 /App/x64/libtesseract50.so

RUN ln -s /usr/lib/x86_64-linux-gnu/* /App/x64/

RUN dotnet build "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PaperlessRestService.ServiceAgents.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PaperlessRestService.ServiceAgents.dll"]