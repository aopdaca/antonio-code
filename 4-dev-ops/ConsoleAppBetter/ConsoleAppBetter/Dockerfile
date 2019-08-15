FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /app/src

COPY . ./

RUN dotnet publish -o publish

FROM mcr.microsoft.com/dotnet/core/runtime:2.2

WORKDIR /app

COPY --from=build /app/scr/publish ./

CMD ["dotnet", "ConsoleAppBetter.dll"]