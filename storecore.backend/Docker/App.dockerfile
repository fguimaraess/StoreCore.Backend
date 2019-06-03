FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
ARG WEBAPP_VERSION=0.0.1
LABEL maintainer=felipeemg@gmail.com \
    Name=webapp \
    Version=${WEBAPP_VERSION}
ARG URL_PORT
WORKDIR /app
ENV NUGET_XMLDOC_MODE skip
ENV ASPNETCORE_URLS http://*:${URL_PORT}
ENTRYPOINT [ "dotnet", "storecore.backend.dll" ]