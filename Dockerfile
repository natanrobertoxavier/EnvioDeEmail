FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /main
COPY ["EnvioDeEmail.Api/EnvioDeEmail.Api.csproj", "EnvioDeEmail.Api/"]
RUN dotnet restore "EnvioDeEmail.Api/EnvioDeEmail.Api.csproj"
COPY . .

RUN dotnet build "EnvioDeEmail.Api/EnvioDeEmail.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EnvioDeEmail.Api/EnvioDeEmail.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EnvioDeEmail.Api.dll"]
