FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Valhalla.Api/Valhalla.Api.csproj", "Valhalla.Api/"]
RUN dotnet restore "Valhalla.Api/Valhalla.Api.csproj"
COPY . .
WORKDIR "/src/Valhalla.Api"
RUN dotnet build "Valhalla.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Valhalla.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Valhalla.Api.dll"]
