#CMD ASPNETCORE_URLS=http://*:$PORT dotnet 
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
ENV ASPNETCORE_URLS="http://*:8443"
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "Gerb.Telegram.Bot.dll"]