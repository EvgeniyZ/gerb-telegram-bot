FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# build runtime image
FROM microsoft/dotnet:runtime
WORKDIR /app

COPY --from=build-env /app/out ./
CMD ASPNETCORE_URLS=http://*:$PORT dotnet Gerb.Telegram.Bot.dll
#ENTRYPOINT ["dotnet", "Gerb.Telegram.Bot.dll"]