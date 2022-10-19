#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443
ENV ASPNETCORE_URLS http://+5001
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["Books.Api/Books.Api.csproj", "Books.Api/"]
COPY ["Books.Infrastructure/Books.Infrastructure.csproj", "Books.Infrastructure/"]
COPY ["Books.Models/Books.Data.csproj", "Books.Models/"]
COPY ["Books.Services/Books.Services.csproj", "Books.Services/"]

RUN dotnet restore "Books.Api/Books.Api.csproj"
COPY ["Books.Api/*", "Books.Api/"]
COPY ["Books.Infrastructure/*", "Books.Api/Books.Infrastructure/"]
COPY ["Books.Models/*", "Books.Api/Books.Data/"]
COPY ["Books.Services/*", "Books.Api/Books.Services/"]

WORKDIR "/src/Books.Api"
RUN dotnet build "Books.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Books.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Books.Api.dll"]