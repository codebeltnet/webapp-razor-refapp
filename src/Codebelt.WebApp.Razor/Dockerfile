FROM mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src

COPY ["Codebelt.WebApp.Razor.csproj", "Codebelt.WebApp.Razor/"]
RUN dotnet restore "Codebelt.WebApp.Razor/Codebelt.WebApp.Razor.csproj" -s https://nuget.cuemon.net/v3/index.json -s https://api.nuget.org/v3/index.json

COPY [".", "Codebelt.WebApp.Razor/"]

WORKDIR "/src/Codebelt.WebApp.Razor"
RUN dotnet build "Codebelt.WebApp.Razor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Codebelt.WebApp.Razor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Codebelt.WebApp.Razor.dll"]