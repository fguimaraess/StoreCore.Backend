# StoreCore.Backend

DOCKERFILE:
FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app
COPY . .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Store.API.dll

PARA FAZER O DEPLOY NO HEROKU - Dentro de Store.API:

- dotnet publish -c Release
- docker build -t storecore.backend ./bin/release/netcoreapp2.1/publish
- heroku login
- heroku container:login
- docker tag storecore.backend registry.heroku.com/store-core/web
- docker push registry.heroku.com/store-core/web﻿
- heroku container:release web -a store-core


ATUALIZAR MIGRATIONS:
- cd Store.DAL/
- dotnet ef --startup-project ../Store.API/ migrations add Initial
- cd ../Store.API
- dotnet ef database update