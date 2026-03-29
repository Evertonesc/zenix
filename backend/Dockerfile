FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build

WORKDIR /src

COPY ["src/Zenix/Zenix.fsproj", "Zenix/"]
RUN dotnet restore "Zenix/Zenix.fsproj"

COPY src/Zenix/ Zenix/
WORKDIR "/src/Zenix"
RUN dotnet build "Zenix.fsproj" -c Release -o /app/build

RUN dotnet publish "Zenix.fsproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime

WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80
EXPOSE 80

ENTRYPOINT ["dotnet", "Zenix.dll"]
