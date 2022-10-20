FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /App
ENV ASPNETCORE_URLS http://+5002
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Search.Api/Search.Api.csproj", "Search.Api/"]
RUN dotnet restore "Search.Api/Search.Api.csproj"

COPY . .
WORKDIR "/src/Search.Api"
RUN dotnet build "Search.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Search.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Search.Api.dll"]
