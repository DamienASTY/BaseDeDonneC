FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DbAppCli/DbAppCli.csproj", "DbAppCli/"]
RUN dotnet restore "DbAppCli/DbAppCli.csproj"
COPY . .
WORKDIR "/src/DbAppCli"
RUN dotnet build "DbAppCli.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DbAppCli.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DbAppCli.dll"]
