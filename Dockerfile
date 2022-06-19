FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime

WORKDIR /app

COPY ./src .
RUN dotnet restore

RUN dotnet add package FirebaseAuthentication.net
RUN dotnet add package TweetinviAPI
