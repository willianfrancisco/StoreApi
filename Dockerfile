FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["Store.Application/Store.Application.csproj", "src/Store.Application/"]
COPY ["Store.Domain/Store.Domain.csproj", "src/Store.Domain/"]
COPY ["Store.Infra.Data/Store.Infra.Data.csproj", "src/Store.Infra.Data/"]
COPY ["Store.Infra.Ioc/Store.Infra.Ioc.csproj", "src/Store.Infra.Ioc/"]
COPY ["Store.WebApi/Store.WebApi.csproj", "src/Store.WebApi/"]
RUN dotnet restore "src/Store.WebApi/Store.WebApi.csproj"
COPY . .
WORKDIR "/src/Store.WebApi"
RUN dotnet build "Store.WebApi.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "Store.WebApi.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Store.WebApi.dll"]
