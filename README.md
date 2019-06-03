# StoreCore.Backend

DOCKERFILE:
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet storecore.backend.dll

PARA FAZER O DEPLOY NO HEROKU:

- dotnet publish -c Release
- docker build -t storecore.backend ./bin/release/netcoreapp2.1/publish
- heroku login
- heroku container:login
- docker tag storecore.backend registry.heroku.com/store-core/web
- docker push registry.heroku.com/store-core/web﻿
- heroku container:release web -a store-core