FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

WORKDIR /app

COPY ./src .
RUN dotnet restore
RUN dotnet publish -c Release -o dist

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0

WORKDIR /app
COPY --from=build-env /app/dist .

ENV PORT=8080
EXPOSE 8080

ENTRYPOINT ["dotnet", "app.dll"]
