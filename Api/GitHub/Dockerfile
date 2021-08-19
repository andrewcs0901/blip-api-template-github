FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["GitHub.Facades/GitHub.Facades.csproj", "GitHub.Facades/"]
COPY ["GitHub.Models/GitHub.Models.csproj", "GitHub.Models/"]
COPY ["GitHub.Services/GitHub.Services.csproj", "GitHub.Services/"]
COPY ["GitHub/GitHub.csproj", "GitHub/"]

RUN dotnet restore "GitHub/GitHub.csproj"
COPY . .
WORKDIR "/src/GitHub"
RUN dotnet build "GitHub.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GitHub.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GitHub.dll"]