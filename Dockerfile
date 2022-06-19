FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime

WORKDIR /app

COPY ./src .
RUN dotnet restore
