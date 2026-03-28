FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["src/Zenix.Api/Zenix.Api.fsproj", "Zenix.Api/"]
RUN dotnet restore "Zenix.Api/Zenix.Api.fsproj"

COPY src/Zenix.Api/ Zenix.Api/
WORKDIR "/src/Zenix.Api"
RUN dotnet build "Zenix.Api.fsproj" -c Release -o /app/build

RUN dotnet publish "Zenix.Api.fsproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Zenix.Api.dll"]
