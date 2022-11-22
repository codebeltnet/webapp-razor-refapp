FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
WORKDIR /src

COPY ["Codebelt.Template.WebApp.Razor.csproj", "Codebelt.Template.WebApp.Razor/"]
RUN dotnet restore "Codebelt.Template.WebApp.Razor/Codebelt.Template.WebApp.Razor.csproj" -s https://nuget.codebelt.net/v3/index.json -s https://api.nuget.org/v3/index.json

COPY [".", "Codebelt.Template.WebApp.Razor/"]

WORKDIR "/src/Codebelt.Template.WebApp.Razor"
RUN dotnet build "Codebelt.Template.WebApp.Razor.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Codebelt.Template.WebApp.Razor.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app

COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Codebelt.Template.WebApp.Razor.dll"]